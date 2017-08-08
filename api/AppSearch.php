<?php
session_start();
require_once("conn.conf.php");
$sql = "select account_id,username,current_ctry_id,age_id,usage_purpose_id,active from accounts";
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
	if ($stmtsearch->execute()) 
	{
		$userArray = array();
		
		while ($row = $stmtsearch->fetch(PDO::FETCH_ASSOC)) {
			$userImage;
				//echo $row["user_image"];
			$userID = $row["account_id"];
			$stmtgetimage = $dbh->prepare("select * from images where account_id=:id LIMIT 1");
			$stmtgetimage->bindParam(':id',$user);
			$user = $userID;
			//echo $userID;
			if ($stmtgetimage->execute()) 
			{
				$imageRow = $stmtgetimage->fetch(PDO::FETCH_ASSOC);
					//echo '<br/>'.$imageRow['image_id'];
				  if($imageRow['image_name'] != ""){
						$filename = file_get_contents("../uimg/Thumbs/".$imageRow['image_name'].".jpg");
						$userImage = base64_encode($filename);
				  }
			}
			
			$currentUser = array(
					"ID" => $row["account_id"], "UserName" => $row["username"], "UsagePurposeId" => $row["usage_purpose_id"],
					"Age" => $row["age_id"], "CurrentCountryId" => $row["current_ctry_id"], "Active" => $row["active"], "ImageBase64" => $userImage
				);
				
				array_push($userArray,$currentUser);
		}
		//$datasearch = $stmtsearch->fetchAll();
	}
	echo json_encode($userArray);
?>
		
