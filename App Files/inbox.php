<?php

	require_once("conn.conf.php");
	
	if(isset($_POST["userid"]))
	{
		$stmtinbox = $dbh->prepare("select message_id,from_account,subject,message_date,message_read,body from messages where to_account=:account and message_status !=:msgstat");
		$stmtinbox->bindParam(':account',$acc);
		$stmtinbox->bindParam(':msgstat',$msgstat);
		$acc = $_POST['userid'];
		$msgstat = 'D';
		
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