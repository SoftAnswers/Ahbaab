<?php

require_once("conn.conf.php");
	
	if(isset($_POST["userid"]))
	{
		$stmtDelete = $dbh->prepare("DELETE FROM `messages` WHERE `messages`.`message_id` = :messageId");
		$stmtDelete->bindParam(':messageId',$messageId);
		$messageId = $_POST['messageId'];
		
		if($stmtDelete->execute())
		{
			echo "Message Deleted Successfully";
		}
		else{
			echo "failed to delete message";
		}
	}
	else{
		echo "No Message ID Set";
	}
?>