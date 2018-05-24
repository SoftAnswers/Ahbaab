<?php

	require_once("conn.conf.php");
	
	if(isset($_POST["userId"]))
	{
		$stmtinbox = $dbh->prepare("select messages.message_id,messages.from_account,messages.subject,messages.message_date,messages.message_read,messages.body,messages.message_type, messages.audio_path,accounts.username from messages inner join accounts where messages.from_account=accounts.account_id and to_account=:account and message_status=:msgstat");
		$stmtinbox->bindParam(':account',$acc);
		$stmtinbox->bindParam(':msgstat',$msgstat);
		$acc = $_POST['userId'];
		$msgstat = 'A';
		
		if($stmtinbox->execute())
		{
			$messageCount = $stmtinbox->rowCount();
			
			if($messageCount > 0)
			{
				$data = $stmtinbox->fetchAll();
		
				$retVal = array();

				foreach($data as $currentRow) {

					$currentMessage = array("message_id"=> $currentRow["message_id"],
					"from_account"=> $currentRow["from_account"],
					"subject"=> $currentRow["subject"],
					"message_date"=> $currentRow["message_date"],
					"message_read"=> $currentRow["message_read"],
					"body"=> $currentRow["body"],
					"message_type"=> $currentRow["message_type"],
					"audio_path"=> $currentRow["audio_path"],
					"username"=> $currentRow["username"],
					"audio_message"=>"");

					if ($currentRow['message_type'] == 'audio') {

						$audioMessage= array("FileBytes"=> "",
						"FileName"=> "",
						"FileExtension"=> "");

						$audioFile = null;
						
						try{
							$audioFile = file_get_contents($currentRow['audio_path']);
						}
						catch (Exception $ex){

						}
						
						if($audioFile !=null){
							$encodedAudioFile = base64_encode($audioFile);
							
							$audioMessage["FileBytes"] = $encodedAudioFile;
							$audioMessage["FileName"] = basename($currentRow['audio_path']);
							$audioMessage["FileExtension"] = '.mp3';

							$currentMessage["audio_message"] = $audioMessage;
						}
					}

					array_push($retVal,$currentMessage);
				}

				echo json_encode($retVal);
			}
			else{
				echo "NO MESSAGES FOUND";
			}
		}
	}
	else{
		echo "No User ID Set";
	}
?>