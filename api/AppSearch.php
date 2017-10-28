<?php
session_start();
require_once("conn.conf.php");
$sql = "select * from accounts";
$param = "";
$begincondition = false;
if(isset($_POST['active']) || isset($_GET['active']))
{
	if($begincondition == true)
	{
		$sql = $sql .' and active= :active';
	}
	else
	{
		$sql = $sql .' where active= :active';
		$begincondition = true;
	}
}
if((isset($_POST['user']) && $_POST['user'] !="") || isset($_GET['user']))
{
	if($begincondition == true)
	{
		$sql = $sql .' and username like :user';
	}
	else
	{
		$sql = $sql .' where username like :user';
		$begincondition = true;
	}
}

if((isset($_POST['gender'])) || isset($_GET['gender']))
{
	if($begincondition == true)
	{
		$sql = $sql .' and gender= :gender';
	}
	else
	{
		$sql = $sql .' where gender= :gender';
		$begincondition = true;
	}
}
if((isset($_POST['status']) && $_POST['status'] != "إختر") || isset($_GET['status']))
{
	if($begincondition == true)
	{
		$sql = $sql .' and status_id= :status';
	}
	else
	{
		$sql = $sql .' where status_id= :status';
		$begincondition = true;
	}
}
if((isset($_POST['usagepurpose']) && $_POST['usagepurpose'] != "إختر") || isset($_GET['usagepurpose']))
{
	if($begincondition == true)
	{
		$sql = $sql . ' and usage_purpose_id = :usage';
	}
	else
	{
		$sql = $sql .' where usage_purpose_id = :usage';
		$begincondition = true;
	}
}
if((isset($_POST['age']) && $_POST['age'] != "إختر") || isset($_GET['age']))
{
	if($begincondition == true)
	{
		$sql = $sql . ' and age_id = :age';
	}
	else
	{
		$sql = $sql .' where age_id = :age';
		$begincondition = true;
	}
}
if((isset($_POST['origin']) && $_POST['origin'] != "إختر") || isset($_GET['origin']))
{
	if($begincondition == true)
	{
		$sql = $sql . ' and origin_ctry_id = :origin';
	}
	else
	{
		$sql = $sql .' where origin_ctry_id = :origin';
		$begincondition = true;
	}
}
if((isset($_POST['current']) && $_POST['current'] != "إختر") || isset($_GET['current']))
{
	if($begincondition == true)
	{
		$sql = $sql . ' and current_ctry_id = :current';
	}
	else
	{
		$sql = $sql .' where current_ctry_id = :current';
		$begincondition = true;
	}
}
if((isset($_POST['lastactive']) && $_POST['lastactive'] != "إختر") || isset($_GET['lastactive']))
{
	if($begincondition == true)
	{
		$sql = $sql . ' and last_active_date >= :lastactive';
	}
	else
	{
		$sql = $sql .' where last_active_date >= :lastactive';
		$begincondition = true;
	}
}
if($begincondition == true)
{
	$sql= $sql ." and account_status = 'A'";
}
else
{
	$sql= $sql ." where account_status = 'A'";
}

if(isset($_POST['userId']) || isset($_GET['userId']))
{
	if($begincondition == true)
	{
		$sql = $sql . ' and NOT account_id = :userId';
	}
	else
	{
		$sql = $sql .' where NOT account_id = :userId';
		$begincondition = true;
	}
}

$sql = $sql . ' order by account_id DESC';
$stmtsearch = $dbh->prepare($sql);
if(!isset($_GET['active']))
{
	if(isset($_POST['active']))
	{
		$stmtsearch->bindParam(':active',$active);
		$active = 1;
	}
}
else
{
		$stmtsearch->bindParam(':active',$active);
		$active = $_GET['active'];
}

if(!isset($_GET['user']))
{
	if(isset($_POST['user']) && $_POST['user'] != "")
	{
		$stmtsearch->bindParam(':user',$user);
		$user ='%'.$_POST['user'].'%';
	}
}
else
{
	if(isset($_POST['user']) && $_POST['user'] != "")
	{
		$stmtsearch->bindParam(':user',$user);
		$user ='%'.$_POST['user'].'%';
	}
}

if(!isset($_GET['gender']))
{
	if(isset($_POST['gender']))
	{
		$stmtsearch->bindParam(':gender',$gender);
		$gender = $_POST['gender'];
	}
}
else
{
		if(isset($_POST['gender']))
	{
		$stmtsearch->bindParam(':gender',$gender);
		$gender = $_POST['gender'];
	}
}
if(!isset($_GET['status']))
{
	if(isset($_POST['status']) && $_POST['status'] != "إختر")
	{
		$stmtsearch->bindParam(':status',$status);
		$status = $_POST['status'];
	}
}
else
{
		$stmtsearch->bindParam(':status',$status);
		$status = $_GET['status'];
}
if(!isset($_GET['usagepurpose']))
{
	if(isset($_POST['usagepurpose']) && $_POST['usagepurpose'] != "إختر")
	{
		$stmtsearch->bindParam(':usage',$usage);
		$usage = $_POST['usagepurpose'];
	}
}
else
{
	$stmtsearch->bindParam(':usage',$usage);
	$usage = $_GET['usagepurpose'];
}
if(!isset($_GET['age']))
{
	if(isset($_POST['age']) && $_POST['age'] != "إختر")
	{
		$stmtsearch->bindParam(':age',$age);
		$age = $_POST['age'];
	}
}
else
{
		$stmtsearch->bindParam(':age',$age);
		$age = $_GET['age'];
}
if(!isset($_GET['origin']))
{
	if(isset($_POST['origin']) && $_POST['origin'] != "إختر")
	{
		$stmtsearch->bindParam(':origin',$origin);
		$origin = $_POST['origin'];	
	}
}
else
{
		$stmtsearch->bindParam(':origin',$origin);
		$origin = $_GET['origin'];	
}
if(!isset($_GET['current']))
{
	if(isset($_POST['current']) && $_POST['current'] != "إختر")
	{
		$stmtsearch->bindParam(':current',$current);
		$current = $_POST['current'];
	}
}
else
{
		$stmtsearch->bindParam(':current',$current);
		$current = $_GET['current'];
}
if(!isset($_GET['lastactive']))
{
	if(isset($_POST['lastactive']) && $_POST['lastactive'] != "إختر")
	{
		$stmtsearch->bindParam(':lastactive',$lastactive);
		if (isset($_POST['lastactive']) && $_POST['lastactive'] == "اليوم")
		{
			$lastactive = date('Y-m-d');
		}
		if(isset($_POST['lastactive']) && $_POST['lastactive'] == "منذ أسبوع")
		{
			$lastactive = date("Y-m-d", mktime(0, 0, 0, date("m") , date("d")-7,date("Y")));
		}
		if(isset($_POST['lastactive']) && $_POST['lastactive'] == "منذ أسبوعين")
		{
			$lastactive = date("Y-m-d", mktime(0, 0, 0, date("m") , date("d")-14,date("Y")));
		}
		if(isset($_POST['lastactive']) && $_POST['lastactive'] == "منذ شهر")
		{
				$lastactive = date("Y-m-d", mktime(0, 0, 0, date("m") , date("d")-30,date("Y")));
		}
		if(isset($_POST['lastactive']) && $_POST['lastactive'] == "منذ ثلاثة أشهر")
		{
			$lastactive = date("Y-m-d", mktime(0, 0, 0, date("m") , date("d")-90,date("Y")));
		}
		if(isset($_POST['lastactive']) && $_POST['lastactive'] == "منذ سنة")
		{
			$lastactive = date("Y-m-d", mktime(0, 0, 0, date("m") , date("d"),date("Y")-1));
		}
	}
}
else
{
	$stmtsearch->bindParam(':lastactive',$lastactive);
	$lastactive = $_GET['lastactive'];
}

if(!isset($_GET['userId']))
{
	if(isset($_POST['userId']))
	{
		$stmtsearch->bindParam(':userId',$id);
		$id = $_POST['userId'];	
	}
}
else
{
		$stmtsearch->bindParam(':userId',$id);
		$id = $_GET['userId'];	
}

	if ($stmtsearch->execute()) 
	{
		$userArray = array();
		
		while ($row = $stmtsearch->fetch(PDO::FETCH_ASSOC)) {
			$userImage;
			$stmtgetimage = $dbh->prepare("select * from images where account_id=:id LIMIT 1");
			$stmtgetimage->bindParam(':id',$user);
			$user = $row["account_id"];
			$images = array();
			$imageNames = array();
			if ($stmtgetimage->execute()){
				$imageRow = $stmtgetimage->fetch(PDO::FETCH_ASSOC);
				  if($imageRow['image_name'] != ""){
						$filename = file_get_contents("../uimg/Thumbs/".$imageRow['image_name'].".jpg");
						$userImage = base64_encode($filename);
						array_push($images,$userImage);
						array_push($imageNames,$imageRow['image_name']);
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
?>
		
