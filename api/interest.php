<?php
	require_once("conn.conf.php");
		$from = $_POST['from'];
		$to = $_POST['to'];
		$date = date('Y-m-d');
		
		// Getting the interests to count to update them 
		$interestTo = $dbh->prepare("SELECT interests_to from `accounts` WHERE account_id=:to");
		$interestTo->bindParam(':to',$to);
		$interestToCount;
		if($interestTo->execute()){
			$user = $interestTo->fetch(PDO::FETCH_ASSOC);
			$interestToCount = $user['interests_to'];
		}
		$interestToCount++;
		//Updating the interests to 
		$updateInterestTo = $dbh->prepare("UPDATE accounts SET interests_to=:count WHERE account_id=:to");
		$updateInterestTo->bindParam(':to',$to);
		$updateInterestTo->bindParam(':count',$interestToCount);
		$updateInterestTo->execute();
		
		// Getting the interests from count to update them 
		$interestFrom = $dbh->prepare("SELECT interests_from from `accounts` WHERE account_id=:from");
		$interestFrom->bindParam(':from',$from);
		$interestFromCount;
		if($interestFrom->execute()){
			$user = $interestFrom->fetch(PDO::FETCH_ASSOC);
			$interestFromCount = $user['interests_from'];
		}
		$interestFromCount++;
		//Updating the interests from 
		$updateInterestFrom = $dbh->prepare("UPDATE accounts SET interests_from=:count WHERE account_id=:from");
		$updateInterestFrom->bindParam(':from',$from);
		$updateInterestFrom->bindParam(':count',$interestFromCount);
		$updateInterestFrom->execute();
			
		$stmt = $dbh->prepare("INSERT INTO `interests` (`interest_from`, `interest_to`, `interest_date`)VALUES (:from, :to, :date)");
		$stmt->bindParam(':from',$from);
		$stmt->bindParam(':to',$to);
		$stmt->bindParam(':date', $date);
		
		if($stmt->execute())
		{
			echo "interest success";
		}
		else{
			echo "interest failed";
		}
	
?>