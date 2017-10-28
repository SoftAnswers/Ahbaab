<?php

//$rootusername="ahbaar_2";
//$rootpassword="KvpjR9x2VEBeAt3R";
//$database="ahbaar_db2";

$rootusername="root";
$rootpassword="";
$database="ahbaar_db";

$mysqli = new mysqli("localhost",$rootusername,$rootpassword, $database);

	if (mysqli_connect_errno()) {
		echo "Connect failed: %s\n", mysqli_connect_error();
		exit();
	}
	
	$username = $_POST['UserName'];
	$password = $_POST['Password'];
	
	$query = "SELECT * from accounts WHERE username LIKE '{$username}' AND password LIKE '{$password}' LIMIT 1";
	
	$result = mysqli_query($mysqli, $query);
	 	
	if (!$result->num_rows == 1) {
		echo "Invalid UserName/Password";
	} else {
		
		$userQuery = "SELECT * FROM accounts WHERE username LIKE '{$username}'";
		
		$userArray = array();
		
		if ($result = mysqli_query($mysqli, $userQuery)) {

			/* fetch associative array */
			while ($row = mysqli_fetch_assoc($result)) {
				
				require_once("conn.conf.php");
				$user = $row["account_id"];
				
				$stmt = $dbh->prepare("Update accounts set last_active_date=:date where account_id=:account");
				$stmt->bindParam(':account',$user);
				$stmt->bindParam(':date',$date);
				$date = date('Y-m-d');
				$stmt->execute();
				
				$loginsCount = $row["logins"] + 1;
				//Updating the logins 
				$updateLogins = $dbh->prepare("UPDATE accounts SET logins=:count WHERE account_id=:user");
				$updateLogins->bindParam(':user',$user);
				$updateLogins->bindParam(':count',$loginsCount);
				$updateLogins->execute();
				
				$today_dt = new DateTime($date);
				$expire_dt = new DateTime($row["paid_end"]);
				if ($expire_dt < $today_dt) {
					$updatePaid = $dbh->prepare("UPDATE accounts SET paid=:isPaid WHERE account_id=:user");
					$updatePaid->bindParam(':user',$user);
					$updatePaid->bindParam(':isPaid', $pay);
					$pay = "N";
					$updatePaid->execute();
				}
		
				$userImage = null;
				$imageNames = array();
				$images = array();
				$stmtgetimage = $dbh->prepare("select * from images where account_id=:id");
				$stmtgetimage->bindParam(':id',$user);
				
				if ($stmtgetimage->execute()) 
				{
					$imageRows = $stmtgetimage->fetchAll(PDO::FETCH_ASSOC);
					foreach($imageRows as $imageRow) {
						if (!empty($imageRow['image_name'])) {
							$filename = file_get_contents("../uimg/Thumbs/".$imageRow['image_name'].".jpg");
							$userImage = base64_encode($filename);
							array_push($images,$userImage);
							array_push($imageNames,$imageRow['image_name']);
						}
					}
				}
				
				$contactWays = array();
				$stmtgetContactWay = $dbh->prepare("select * from contact_preferences where account_id=:id");
				$stmtgetContactWay->bindParam(':id',$user);
				
				if ($stmtgetContactWay->execute()) {
					$contactWayRow = $stmtgetContactWay->fetchAll(PDO::FETCH_ASSOC);
					foreach($contactWayRow as $wayRow) {
						$way = array("way_value" => $wayRow['way_value'], "way_id" => $wayRow['way_id']);
						array_push($contactWays,$way);
					}
				}
				$currentUser = array(
					"ID" => $row["account_id"], "UserName" => $row["username"], "Password" => $row["password"],
					"Email" => $row["email"], "Name" => $row["name"], "Gender" => $row["gender"],
					"Status" => $row["status_id"], "IP" => $row["IP"], "LastActiveDate" => $row["last_active_date"],
					"CreatedOn" => $row["created_on"], "EyesColorId" => $row["eye_color_id"], "HairColorId" => $row["hair_color_id"],
					"HeightId" => $row["height_id"], "WeightId" => $row["weight_id"], "UsagePurposeId" => $row["usage_purpose_id"],
					"Age" => $row["age_id"], "EducationLevelID" => $row["educ_level_id"], "OriginCountryId" => $row["origin_ctry_id"],
					"CurrentCountryId" => $row["current_ctry_id"], "JobId" => $row["job_id"], "SelfDescription" => $row["describe_you"],
					"OthersDescription" => $row["describe_others"], "PhoneNumber" => $row["phone_number"], "Paid" => $row["paid"],
					"VisitCountTo" => $row["visit_count_to"], "VisitCountFrom" => $row["visit_count_from"], "InterestsTo" => $row["interests_to"],
					"InterestsFrom" => $row["interests_from"], "BlocksTo" => $row["blocks_to"], "BlocksFrom" => $row["blocks_from"],
					"NumberOfLogins" => $row["logins"], "Active" => $row["active"], "TimeFrameId" => $row["time_frame_id"],
					"PaidStartDate" => $row["paid_begin"], "PaidEndDate" => $row["paid_end"], "AccountStatus" => $row["account_status"],
					"TimeZoneId" => $row["timezone_id"], "ImageBase64" => $images, "ContactWays" => $contactWays, "ImageNames" => $imageNames
				);
				array_push($userArray,$currentUser);
			}
		}
		echo json_encode($userArray);
		
	}
/*}
else{
	echo "Empty username/pass";
}*/

?>