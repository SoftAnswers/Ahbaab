<?php		
	require_once("conn.conf.php");
	
	$userId = $_POST['userId'];
	$stmt = $dbh->prepare("Update accounts set paid='Y', paid_begin=:fromDate, paid_end=:toDate where account_id=:userId");
	$date = date('Y-m-d');
	$time = time();
	$newEndingDate = date('Y-m-d', strtotime('+1 year'));
	$stmt->bindParam(':fromDate',$date);
	$stmt->bindParam(':toDate',$newEndingDate);
	$stmt->bindParam(':userId',$userId);
	$stmt->execute();
	
	$userArray = array();

	$userImage = null;
	$imageNames = array();
	$images = array();
	$stmtgetimage = $dbh->prepare("select * from images where account_id=:id");
	$stmtgetimage->bindParam(':id',$userId);
	
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
	$stmtgetContactWay->bindParam(':id',$userId);
	
	if ($stmtgetContactWay->execute()) {
		$contactWayRow = $stmtgetContactWay->fetchAll(PDO::FETCH_ASSOC);
		foreach($contactWayRow as $wayRow) {
			$way = array("way_value" => $wayRow['way_value'], "way_id" => $wayRow['way_id']);
			array_push($contactWays,$way);
		}
	}
	
	$getUser = $dbh->prepare("SELECT * FROM accounts WHERE account_id=:userId");
	$getUser->bindParam(':userId',$userId);
	
	if ($getUser->execute()) {
		$userRow = $getUser->fetchAll(PDO::FETCH_ASSOC);
		foreach($userRow as $row) {
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
	
	
/*}
else{
	echo "Empty username/pass";
}*/

?>