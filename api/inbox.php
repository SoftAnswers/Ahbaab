<?php

	require_once("conn.conf.php");
	
	if(isset($_POST["userId"]))
	{
		$stmtinbox = $dbh->prepare("select messages.message_id,messages.from_account,messages.subject,messages.message_date,messages.message_read,messages.body,accounts.username from messages inner join accounts where messages.from_account=accounts.account_id and to_account=:account and message_status=:msgstat");
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
		
				echo json_encode($data);
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