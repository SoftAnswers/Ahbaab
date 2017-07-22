<?php

$rootusername="ahbaar_2";
$rootpassword="KvpjR9x2VEBeAt3R";
$database="ahbaar_db2";

$mysqli = new mysqli("localhost",$rootusername,$rootpassword, $database);

//if(isset($_POST["UserName"]) && isset($_POST["Password"]))
//{
	if (mysqli_connect_errno()) {
		echo "Connect failed: %s\n", mysqli_connect_error();
		exit();
	}
	
	$username = $_POST['UserName'];
	$password = $_POST['Password'];
	
	$query = "SELECT * from accounts WHERE username LIKE '{$username}' AND password LIKE '{$password}' LIMIT 1";
	
	$result = mysqli_query($mysqli, $query);
	 
	//$result = $mysqli->query($sql);
	
	if (!$result->num_rows == 1) {
		echo "Invalid UserName/Password";
	} else {
		
		$userQuery = "SELECT * FROM accounts WHERE username LIKE '{$username}'";
		
		$userArray = array();
		
		if ($result = mysqli_query($mysqli, $userQuery)) {

			/* fetch associative array */
			while ($row = mysqli_fetch_assoc($result)) {
				
				require_once("conn.conf.php");
				$userImage;
				//echo $row["user_image"];
				$userID = $row["account_id"];
				$stmtgetimage = $dbh->prepare("select * from images where account_id=:id LIMIT 1");
				$stmtgetimage->bindParam(':id',$user);
				$user = $userID;
				//echo $userID;
				if ($stmtgetimage->execute()) 
				{
					$imageRow = $stmtgetimage->fetch(PDO::FETCH_BOTH);
						//echo '<br/>'.$imageRow['image_id'];
					  
						$filename = file_get_contents("/uimg/Thumbs/".$imageRow['image_name'].".jpg");
						$userImage = base64_encode($filename);
						echo $imageRow;
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
					"TimeZoneId" => $row["timezone_id"], "ImageBase64" => $userImage
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