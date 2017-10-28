<?php

//$username="ahbaar_2";
//$password="KvpjR9x2VEBeAt3R";
//$database="ahbaar_db2";

$username="root";
$password="";
$database="ahbaar_db";

$mysqli = new mysqli("localhost",$username,$password, $database);

if(isset($_POST["TableName"]))
{
	if (mysqli_connect_errno()) {
		echo "Connect failed: %s\n", mysqli_connect_error();
		exit();
	}
	
	$tableName = $_POST["TableName"];
	$query = "SELECT * FROM `" . $tableName . "`";
	$target;
	if ($tableName == 'visits') {
		$query = $query ."WHERE visit_to=".$_POST["to"];
		$target = "from";
	} else if ($tableName == 'interests') {
		if(isset($_POST["from"])) {
			$query = $query ."WHERE interest_from=".$_POST['from'];
			$target = "to";
		} else {
			$query = $query ."WHERE interest_to=".$_POST['to'];
			$target = "from";
		}
	} else if ($tableName == 'blocks') {
		if(isset($_POST["from"])) {
			$query = $query ."WHERE block_from=".$_POST['from'];
			$target = "to";
		} else {
			$query = $query ."WHERE block_to=".$_POST['to'];
			$target = "from";
		}
	}
	
	$queryResult = mysqli_query($mysqli, $query);
	 
	$itemsArray = array();
	 
	while($row= mysqli_fetch_row($queryResult)) {
		//$currentItem = array("from" => $row[0], "to" => $row[1], "date" => $row[2]);
		require_once("conn.conf.php");
		$user;
		if ($target == "from") {
			$user = $row[0];
		} else {
			$user = $row[1];
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
		
		$stmtgetUsers = $dbh->prepare("SELECT * FROM accounts WHERE account_id=:id");
		$stmtgetUsers->bindParam(':id',$user);
		if ($stmtgetUsers->execute()) {
			$userRow = $stmtgetUsers->fetchALL(PDO::FETCH_ASSOC);
			foreach($userRow as $userData) {
				$currentUser = array(
					"ID" => $userData["account_id"], "UserName" => $userData["username"], "Password" => $userData["password"],
					"Email" => $userData["email"], "Name" => $userData["name"], "Gender" => $userData["gender"],
					"Status" => $userData["status_id"], "IP" => $userData["IP"], "LastActiveDate" => $userData["last_active_date"],
					"CreatedOn" => $userData["created_on"], "EyesColorId" => $userData["eye_color_id"], "HairColorId" => $userData["hair_color_id"],
					"HeightId" => $userData["height_id"], "WeightId" => $userData["weight_id"], "UsagePurposeId" => $userData["usage_purpose_id"],
					"Age" => $userData["age_id"], "EducationLevelID" => $userData["educ_level_id"], "OriginCountryId" => $userData["origin_ctry_id"],
					"CurrentCountryId" => $userData["current_ctry_id"], "JobId" => $userData["job_id"], "SelfDescription" => $userData["describe_you"],
					"OthersDescription" => $userData["describe_others"], "PhoneNumber" => $userData["phone_number"], "Paid" => $userData["paid"],
					"VisitCountTo" => $userData["visit_count_to"], "VisitCountFrom" => $userData["visit_count_from"], "InterestsTo" => $userData["interests_to"],
					"InterestsFrom" => $userData["interests_from"], "BlocksTo" => $userData["blocks_to"], "BlocksFrom" => $userData["blocks_from"],
					"NumberOfLogins" => $userData["logins"], "Active" => $userData["active"], "TimeFrameId" => $userData["time_frame_id"],
					"PaidStartDate" => $userData["paid_begin"], "PaidEndDate" => $userData["paid_end"], "AccountStatus" => $userData["account_status"],
					"TimeZoneId" => $userData["timezone_id"], "ImageBase64" => $images, "ContactWays" => $contactWays, "ImageNames" => $imageNames
				);
				array_push($itemsArray, $currentUser);
			}
		}
	}
	echo json_encode($itemsArray);
}
else{
	echo "no table name";
}
?>