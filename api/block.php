<?php
	require_once("conn.conf.php");
		$from = $_POST['from'];
		$to = $_POST['to'];
		$date = date('Y-m-d');
		
		// Getting the blocks to count to update them 
		$blockTo = $dbh->prepare("SELECT blocks_to from `accounts` WHERE account_id=:to");
		$blockTo->bindParam(':to',$to);
		$blockToCount;
		if($blockTo->execute()){
			$user = $blockTo->fetch(PDO::FETCH_ASSOC);
			$blockToCount = $user['blocks_to'];
		}
		$blockToCount++;
		//Updating the blocks to 
		$updateBlockTo = $dbh->prepare("UPDATE accounts SET blocks_to=:count WHERE account_id=:to");
		$updateBlockTo->bindParam(':to',$to);
		$updateBlockTo->bindParam(':count',$blockToCount);
		$updateBlockTo->execute();
		
		// Getting the blocks from count to update them 
		$blockFrom = $dbh->prepare("SELECT blocks_from from `accounts` WHERE account_id=:from");
		$blockFrom->bindParam(':from',$from);
		$blockFromCount;
		if($blockFrom->execute()){
			$user = $blockFrom->fetch(PDO::FETCH_ASSOC);
			$blockFromCount = $user['blocks_from'];
		}
		$blockFromCount++;
		//Updating the blocks from 
		$updateBlockFrom = $dbh->prepare("UPDATE accounts SET blocks_from=:count WHERE account_id=:from");
		$updateBlockFrom->bindParam(':from',$from);
		$updateBlockFrom->bindParam(':count',$blockFromCount);
		$updateBlockFrom->execute();
			
		$stmt = $dbh->prepare("INSERT INTO `blocks` (`block_from`, `block_to`, `block_date`)VALUES (:from, :to, :date)");
		$stmt->bindParam(':from',$from);
		$stmt->bindParam(':to',$to);
		$stmt->bindParam(':date', $date);
		
		if($stmt->execute())
		{
			echo "block success";
		}
		else{
			echo "block failed";
		}
	
?>