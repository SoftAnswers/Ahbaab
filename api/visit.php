<?php
	require_once("conn.conf.php");
		$from = $_POST['from'];
		$to = $_POST['to'];
		$date = date('Y-m-d');
		
		// Getting the visits to count to update them 
		$visitTo = $dbh->prepare("SELECT visit_count_to from `accounts` WHERE account_id=:from");
		$visitTo->bindParam(':from',$from);
		$visitToCount;
		if($visitTo->execute()){
			$user = $visitTo->fetch(PDO::FETCH_ASSOC);
			$visitToCount = $user['visit_count_to'];
		}
		$visitToCount++;
		//Updating the visit to 
		$updateVisitTo = $dbh->prepare("UPDATE accounts SET visit_count_to=:count WHERE account_id=:from");
		$updateVisitTo->bindParam(':from',$from);
		$updateVisitTo->bindParam(':count',$visitToCount);
		$updateVisitTo->execute();
		
		// Getting the visits from count to update them 
		$visitFrom = $dbh->prepare("SELECT visit_count_from from `accounts` WHERE account_id=:to");
		$visitFrom->bindParam(':to',$to);
		$visitFromCount;
		if($visitFrom->execute()){
			$user = $visitFrom->fetch(PDO::FETCH_ASSOC);
			$visitFromCount = $user['visit_count_from'];
		}
		$visitFromCount++;
		//Updating the visit from 
		$updateVisitFrom = $dbh->prepare("UPDATE accounts SET visit_count_from=:count WHERE account_id=:to");
		$updateVisitFrom->bindParam(':to',$to);
		$updateVisitFrom->bindParam(':count',$visitFromCount);
		$updateVisitFrom->execute();
		
		$stmt = $dbh->prepare("INSERT INTO `visits` (`visit_from`, `visit_to`, `visit_date`)VALUES (:from, :to, :date)");
		$stmt->bindParam(':from',$from);
		$stmt->bindParam(':to',$to);
		$stmt->bindParam(':date', $date);
		
		if($stmt->execute()){
			echo "visit success";
		}else{
			echo "visit failed";
		}
	
?>