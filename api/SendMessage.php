<?php
	require_once("conn.conf.php");
	define( 'API_ACCESS_KEY', 'AAAAQB6G5LM:APA91bGxLT0MDO4iIuw-o6gPxmf7m_HO-N_a-NLXEUcXNubBdnnXXBmVd9L3Qfnee4adCZwgzMX1PXiqEV3zS_fV0U5qEUPWWQRka0BF8aYDCGhDPJBlrR_RmZ8i2anQFjo_Xl6oXghh');
	
	$dbh->setAttribute( PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION );
	$stmt = $dbh->prepare("INSERT INTO messages (from_account,to_account,subject,body,message_status,message_date,message_read,message_type,audio_path) VALUES 
	(:from,:to,:subject,:body,:messageStatus,:date,:read,:msgtype,:audioPath)");
	$stmt->bindParam(':from',$from);
	$stmt->bindParam(':to',$to);
	$stmt->bindParam(':subject', $subject);
	$stmt->bindParam(':body', $body);
	$stmt->bindParam(':messageStatus', $status);
	$stmt->bindParam(':date', $date);
	$stmt->bindParam(':msgtype',$msgtype);
	$stmt->bindParam(':read',$read);
	$stmt->bindParam(':audioPath',$audioPath);
	$from = $_POST['from'];
	$to = $_POST['to'];
	$subject = $_POST['subject'];
	$body = $_POST['body'];
	$date = date('Y-m-d');
	if($_POST['gender'] == 'M')
	{
		$status = 'A';
	}
	else
	{
		$status = 'P';					
	}

	$audioMessage = json_decode($_POST["audioMessage"]);

	if($audioMessage!=null && $audioMessage->{'FileName'}!=""){

		$msgtype = 'voice';	

		$uploadsDirectory = "../audiofiles/";
		
		$now = time();
		
		$uploadFilename = $uploadsDirectory.$now.'-'.$audioMessage->{'FileName'};

		$decodedAudioContents = base64_decode($audioMessage->{'FileBytes'});

		file_put_contents($uploadFilename, base64_decode($audioMessage->{'FileBytes'}));

		$audioPath = $uploadFilename;
		//file_force_contents($uploadFilename,$decodedAudioContents);
	}
	else{
		$msgtype = 'text';
		$audioPath = '';
	}
	$read = 'N';

	if($stmt->execute())
	{
		$lastid = $dbh->lastInsertId();

		sendMobileNotification($lastid);

		echo "success";
	}
	else{
		echo $dbh->errorInfo()[1];
	}

	function sendMobileNotification($messageId){

		if($_POST['gender'] == 'M')
		{
			$user = 'root';
			$pass = '';
			$dbh = new PDO('mysql:host=localhost;dbname=ahbaar_db',$user, $pass);
			
			$selectExistingUserTokenStatement = $dbh->prepare("SELECT app_firebase_tokens.app_firebase_token,accounts.username,accounts.paid FROM app_firebase_tokens INNER JOIN accounts WHERE app_firebase_tokens.account_id=accounts.account_id AND accounts.account_id=:user");

    		$selectExistingUserTokenStatement->bindParam(':user',$userId);

			$userId = $_POST['to'];

    		if($selectExistingUserTokenStatement->execute()){
				
				$row = $selectExistingUserTokenStatement->fetch(PDO::FETCH_ASSOC);
				
				echo($row['app_firebase_token']);
				
				$data = array(
					'messageId' => $messageId,
					'username' => $row['username'],
					'isUserPaid'=> $row['paid']
				 );

				$fcmMsg = array(
					'body' => 'لقد وصلتك رسالة جديدة',
					'title' => 'أساور',
					'content_available' => true
				);

				$fcmFields = array(
					'to' => $row['app_firebase_token'],
					'priority' => 'high',
					'notification' => $fcmMsg,
					'data' => $data
				);
				
				$headers = array(
					'Authorization: key=' .API_ACCESS_KEY,
					'Content-Type: application/json'
				);
				
				$ch = curl_init();
				curl_setopt( $ch,CURLOPT_URL, 'https://fcm.googleapis.com/fcm/send');
				curl_setopt( $ch,CURLOPT_POST, true);
				curl_setopt( $ch,CURLOPT_HTTPHEADER, $headers);
				curl_setopt( $ch,CURLOPT_RETURNTRANSFER, true);
				curl_setopt( $ch,CURLOPT_SSL_VERIFYPEER, false);
				curl_setopt( $ch,CURLOPT_POSTFIELDS, json_encode($fcmFields));
				$result = curl_exec($ch);
				curl_close($ch);
				echo("sent");
			}
		}
	}

	function file_force_contents($dir, $contents){
        $parts = explode('/', $dir);
        $file = array_pop($parts);
        $dir = '';
        foreach($parts as $part)
            if(!is_dir($dir .= "/$part")) mkdir($dir);
		$filename = substr("$dir/$file", 1);
        file_put_contents("$filename", $contents);
    }
?>