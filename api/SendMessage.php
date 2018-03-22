<?php
	require_once("conn.conf.php");
	
			
		$stmt = $dbh->prepare("INSERT INTO `messages` (`message_id`, `from_account`, `to_account`,`subject`, `body`, `message_status`, `message_date`, `message_read`)VALUES (NULL, :from, :to, :subject, :body, :messageStatus, :date, 'N')");
		$stmt->bindParam(':from',$from);
		$stmt->bindParam(':to',$to);
		$stmt->bindParam(':subject', $subject);
		$stmt->bindParam(':body', $body);
		$stmt->bindParam(':date', $date);
		$stmt->bindParam(':messageStatus', $status);
		$from = $_POST['from'];
		$to = $_POST['to'];
		$subject = $_POST['subject'];
		$body = $_POST['body'];
		$date = date('Y-m-d');
		$status = 'P';
		if ($_POST['gender'] == 'M') {
			$status = 'A';
		}
		
		if($stmt->execute())
		{
			echo "success";
		}
		else{
			echo "failed";
		}
	
?>