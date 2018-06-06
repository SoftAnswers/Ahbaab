<?php

require_once("conn.conf.php");
	
	if(isset($_POST["messageId"]))
	{
		$stmtDelete = $dbh->prepare("UPDATE `messages`SET message_read=:messageStatus WHERE message_id=:messageId");
		$stmtDelete->bindParam(':messageStatus', 'Y');
		$stmtDelete->bindParam(':messageId', $messageId);
		$messageId = $_POST['messageId'];
		
		if($stmtDelete->execute())
		{
			echo "Message Updated Successfully";
		}
		else{
			echo "failed to update message";
		}
	}
	else{
		echo "No Message ID Set";
	}
?>