<?php
	require_once("conn.conf.php");
	
	$dbh->setAttribute( PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION );
	$stmt = $dbh->prepare("INSERT INTO messages (from_account,to_account,subject,body,message_status,message_date,message_read,message_type,audio_path) VALUES 
	(:from,:to,:subject,:body,:messageStatus,:date,:read,:msgtype,:audioPath)");
	$stmt->bindParam(':from',$from);
	$stmt->bindParam(':to',$to);
	$stmt->bindParam(':subject', $subject);
	$stmt->bindParam(':body', $body);
	$stmt->bindParam(':date', $date);
	$stmt->bindParam(':messageStatus', $status);
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

		$msgtype = 'audio';	

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

		echo "success, and audio is null";
	}
	else{
		echo $dbh->errorInfo()[1];
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