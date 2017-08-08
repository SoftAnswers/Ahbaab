<?php
	require_once("conn.conf.php");
	
			
		$stmt = $dbh->prepare("INSERT INTO `interests` (`interest_from`, `interest_to`, `interest_date`)VALUES (:from, :to, :date)");
		$stmt->bindParam(':from',$from);
		$stmt->bindParam(':to',$to);
		$stmt->bindParam(':date', $date);
		$from = $_POST['from'];
		$to = $_POST['to'];
		$date = date('Y-m-d');
		
		if($stmt->execute())
		{
			echo "interest success";
		}
		else{
			echo "interest failed";
		}
	
?>