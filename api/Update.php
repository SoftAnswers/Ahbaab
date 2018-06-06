<?php
	require_once("conn.conf.php");
	if (isset($_POST['userid'])) {
		$stmtcheckaccount = $dbh->prepare("SELECT * from accounts where account_id =:user_id");
		$stmtcheckaccount->bindParam(':user_id',$userId);
		$userId = $_POST['userid'];
		if($stmtcheckaccount->execute()) {
			$countaccount = $stmtcheckaccount->rowCount();
		}
		
		// Checking if the parameters exists
		$userDetails = $stmtcheckaccount->fetch(PDO::FETCH_ASSOC);
		$accountId = $userDetails['account_id'];
		if($_POST['user'] == "") {
			echo "الرجاء إدخال إسم المستخدم";
		}
		if($_POST['pass'] == "") {
			echo "الرجاء إدخال كلمة السر";
		}	
		$pattern = "/^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,3})$/i";
		$email = $_POST['mail'];
		if (!preg_match($pattern,$email)) {
			echo "الرجاء إدخال البريد الإلكتروني بشكل صحيح";
		}
		if($_POST['describeyou'] == "") {
			echo "الرجاء تعبئة خانة أوصف نفسك";
		}
		if($_POST['describeother'] == "") {
			echo "الرجاء تعبئة خانة أوصف الشريك";
		}
		if($_POST['name'] == "") {
			echo "الرجاء كتابة الإسم الكامل";
		}
		if($_POST['status'] == "") {
			echo "الرجاء إختيار الوضع العائلي";
		}
		if($_POST['usagepurpose'] == "") {
			echo "الرجاء إختيار الهدف من الموقع";
		}
		if($_POST['age'] == "") {
			echo "الرجاء إختيار الهدف من الموقع";
		}
		if($_POST['current'] == "") {
			echo "الرجاء إختيار بلد السكن";
		}
		
		// Updating the account
		$stmt = $dbh->prepare("Update accounts set password=:pass, email=:mail, name=:name, status_id=:status, eye_color_id=:eyecolor, hair_color_id=:haircolor, height_id=:height, weight_id=:weight, usage_purpose_id=:usagepurpose, age_id=:age, educ_level_id=:educlevel, origin_ctry_id=:origin, current_ctry_id = :current, job_id=:job, describe_you=:describeyou, describe_others=:describeother, time_frame_id=:timeframe, timezone_id=:timezone where account_id=:account");
		$stmt->bindParam(':pass',$pass);
		$stmt->bindParam(':mail',$mail);
		$stmt->bindParam(':name',$name);
		$stmt->bindParam(':status',$status);
		$stmt->bindParam(':eyecolor', $eyecolor);
		$stmt->bindParam(':haircolor', $haircolor);
		$stmt->bindParam(':height', $height);
		$stmt->bindParam(':weight', $weight);
		$stmt->bindParam(':usagepurpose', $usagepurpose);
		$stmt->bindParam(':age', $age);
		$stmt->bindParam(':educlevel', $educlevel);
		$stmt->bindParam(':origin', $origin);
		$stmt->bindParam(':current', $current);
		$stmt->bindParam(':job', $job);
		$stmt->bindParam(':describeyou', $describeyou);
		$stmt->bindParam(':describeother', $describeother);
		$stmt->bindParam(':timeframe', $timeframe);
		$stmt->bindParam(':timezone', $timezone);
		$stmt->bindParam(':account',$accountId);
		$pass = $_POST['pass'];
		$mail = $_POST['mail'];
		$name = $_POST['name'];
		$status = $_POST['status'];
		$eyecolor = $_POST['eyecolor'];
		$haircolor = $_POST['haircolor'];
		$height = $_POST['height'];
		$weight = $_POST['weight'];
		$usagepurpose = $_POST['usagepurpose'];
		$age = $_POST['age'];
		$educlevel = $_POST['educlevel'];
		$origin = $_POST['origin'];
		$current = $_POST['current'];
		$job = $_POST['job'];
		$describeyou = $_POST['describeyou'];
		$describeother = $_POST['describeother'];
		$timeframe = $_POST['available'];
		$timezone = $_POST['timezone'];
		$stmt->execute();
		
		// Updating the contact ways
		if(!empty($_POST['way'])) {
			$gender = $_POST['gender'];
			$contactWays = $_POST['way'];
			$stmtdeleteway = $dbh->prepare("DELETE FROM contact_preferences where account_id=:id");
			$stmtdeleteway->bindParam(':id',$accountId);
			$stmtdeleteway->execute();
			
			$contactWay = json_decode($contactWays);
			for($i=0; $i < count($contactWay); $i++) {
				if($gender == "M") {
					$stmtinsertway = $dbh->prepare("insert into contact_preferences (account_id, way_id, way_value, status) values (:acc,:way,:value,:status)");
					$stmtinsertway->bindParam(':acc',$accountId);
					$stmtinsertway->bindParam(':way',$way);
					$stmtinsertway->bindParam(':value',$value);
					$stmtinsertway->bindParam(':status',$status);
					$way = $contactWay[$i]->{'way_id'};
					$value = $contactWay[$i]->{'way_value'};
					$status ='A';
					$stmtinsertway->execute();
				} else {
					$stmtinsertway = $dbh->prepare("insert into contact_preferences (account_id,way_id,way_value,status) values (:acc,:way,:value,:status)");
					$stmtinsertway->bindParam(':acc',$accountId);
					$stmtinsertway->bindParam(':way',$way);
					$stmtinsertway->bindParam(':value',$value);
					$stmtinsertway->bindParam(':status',$status);
					$way = $contactWay[$i];
					$value = $contactWay[$i]->{'way_value'};
					$status = 'P';
					$stmtinsertway->execute();
				}
			}
		}
		// updating the images added
		$img = $_POST["Images"];
		$images = json_decode($img);
		for ($i = 0; $i < count($images); $i++) {
			
			$imageContents = $images[$i]->{'FileBytes'};
			
			$fileName = $images[$i]->{'FileName'};
			$dir = "../uimg/FullSize/";
			$decodedImageContents = base64_decode($imageContents);
			
			file_force_contents('../uimg/FullSize/'.$fileName.".jpg",$decodedImageContents);
			
			createBig("../uimg/FullSize/","../uimg/usized/",600,$fileName.".jpg");
			createThumbs("../uimg/FullSize/","../uimg/Thumbs/",127,$fileName.".jpg");
			$stmtinsertimage = $dbh->prepare("insert into images (image_name,account_id,promoted,is_profile,image_status,promoted_banner) values (:name,:account,'N','N','P','N')");
			$stmtinsertimage->bindParam(':name',$fileName);
			$stmtinsertimage->bindParam(':account',$accountId);
			$stmtinsertimage->execute();
		}
		// Deleting user images if necessary
		if (!empty($_POST['ImagesToDelete'])) {
			$imgToDelete = $_POST['ImagesToDelete'];
			$images = json_decode($imgToDelete);			
			for ($i = 0; $i < count($images); $i++) {
				$fileName = $images[$i]->{'FileName'};
				unlink('../uimg/FullSize/'.$fileName.".jpg");
				unlink("../uimg/usized/".$fileName.".jpg");
				unlink("../uimg/Thumbs/".$fileName.".jpg");
				$stmtdeleteimage = $dbh->prepare("DELETE FROM images where account_id=:id AND image_name=:name");
				$stmtdeleteimage->bindParam(':id',$accountId);
				$stmtdeleteimage->bindParam(':name',$fileName);
				$stmtdeleteimage->execute();
			}
		}
		
		// Fetching the contact ways to return them and add them to the user object
		$contactWays = array();
		$stmtgetContactWay = $dbh->prepare("select * from contact_preferences where account_id=:id");
		$stmtgetContactWay->bindParam(':id',$accountId);
		
		if ($stmtgetContactWay->execute()) {
			$contactWayRow = $stmtgetContactWay->fetchAll(PDO::FETCH_ASSOC);
			foreach($contactWayRow as $wayRow) {
				$way = array("way_value" => $wayRow['way_value'], "way_id" => $wayRow['way_id']);
				array_push($contactWays,$way);
			}
		}
		
		//Fetching the images corresponding to the current user
		$userImage = null;
		$imageNames = array();
		$images = array();
		$stmtgetimage = $dbh->prepare("select * from images where account_id=:id");
		$stmtgetimage->bindParam(':id',$accountId);
		
		if ($stmtgetimage->execute()) 
		{
			$imageRows = $stmtgetimage->fetchAll(PDO::FETCH_ASSOC);
			foreach($imageRows as $row) {
				if (!empty($row['image_name'])) {
					$filename = file_get_contents("../uimg/Thumbs/".$row['image_name'].".jpg");
					$userImage = base64_encode($filename);
					array_push($images,$userImage);
					array_push($imageNames,$imageRow['image_name']);
				}
			}
		}
		
		// Fetching the user details to return them
		$userArray = array();			
		$stmtgetlastinserted = $dbh->prepare("Select * from accounts where account_id=:id");
		$stmtgetlastinserted->bindParam(':id',$accountId);
		if($stmtgetlastinserted->execute()) {
			$data = $stmtgetlastinserted->fetch(PDO::FETCH_ASSOC);
			$currentUser = array(
				"ID" => $data["account_id"], "UserName" => $data["username"], "Password" => $data["password"],
				"Email" => $data["email"], "Name" => $data["name"], "Gender" => $data["gender"],
				"Status" => $data["status_id"], "IP" => $data["IP"], "LastActiveDate" => $data["last_active_date"],
				"CreatedOn" => $data["created_on"], "EyesColorId" => $data["eye_color_id"], "HairColorId" => $data["hair_color_id"],
				"HeightId" => $data["height_id"], "WeightId" => $data["weight_id"], "UsagePurposeId" => $data["usage_purpose_id"],
				"Age" => $data["age_id"], "EducationLevelID" => $data["educ_level_id"], "OriginCountryId" => $data["origin_ctry_id"],
				"CurrentCountryId" => $data["current_ctry_id"], "JobId" => $data["job_id"], "SelfDescription" => $data["describe_you"],
				"OthersDescription" => $data["describe_others"], "PhoneNumber" => $data["phone_number"], "Paid" => $data["paid"],
				"VisitCountTo" => $data["visit_count_to"], "VisitCountFrom" => $data["visit_count_from"], "InterestsTo" => $data["interests_to"],
				"InterestsFrom" => $data["interests_from"], "BlocksTo" => $data["blocks_to"], "BlocksFrom" => $data["blocks_from"],
				"NumberOfLogins" => $data["logins"], "Active" => $data["active"], "TimeFrameId" => $data["time_frame_id"],
				"PaidStartDate" => $data["paid_begin"], "PaidEndDate" => $data["paid_end"], "AccountStatus" => $data["account_status"],
				"TimeZoneId" => $data["timezone_id"], "ContactWays" => $contactWays, "ImageBase64" => $images, "ImageNames" => $imageNames
			);
			
			array_push($userArray,$currentUser);
		}
		echo json_encode($userArray);
	}
	
	function file_force_contents($dir, $contents){
        $parts = explode('/', $dir);
        $file = array_pop($parts);
        $dir = '';
        foreach($parts as $part)
            if(!is_dir($dir .= "/$part")) mkdir($dir);
		$filename = substr("$dir/$file", 1);
        file_put_contents("$filename", $contents);
    }
	
	function createBig($pathToImages, $pathToThumbs, $thumbWidth, $fname) 
	{
	  $dir = opendir($pathToImages);
	  // loop through it, looking for any/all JPG files:
	  //while (false !== ($fname = readdir( $dir ))) {
	  // parse path for the extension
	  $info = pathinfo($pathToImages . $fname);
	  //echo json_encode($info);
	  // continue only if this is a JPEG image
	  if ( strtolower($info['extension']) == 'jpg' ) 
	    {
			//echo "Creating thumbnail for {$fname} <br />";
	       // load image and get image size
		  $img = imagecreatefromjpeg("{$pathToImages}{$fname}");
	      $width = imagesx( $img );
    	  $height = imagesy( $img );
	      // calculate thumbnail size
    	  $new_width = $thumbWidth;
      	  $new_height = floor( $height * ( $thumbWidth / $width ) );
		  
		  
	      // create a new tempopary image
    	  $tmp_img = imagecreatetruecolor( $new_width, $new_height );
	      // copy and resize old image into new image 
    	  imagecopyresized( $tmp_img, $img, 0, 0, 0, 0, $new_width, $new_height, $width, $height );
	      // save thumbnail into a file
    	  imagejpeg( $tmp_img, "{$pathToThumbs}{$fname}" );
	    }
		if ( strtolower($info['extension']) == 'png' ) 
	    {
			//echo "Creating thumbnail for {$fname} <br />";
	       // load image and get image size
		  $img = imagecreatefrompng( "{$pathToImages}{$fname}" );
	      $width = imagesx( $img );
    	  $height = imagesy( $img );
	      // calculate thumbnail size
    	  $new_width = $thumbWidth;
		
		if($width < $height)
	  		{
			  $new_width = 400;
			}
      	  $new_height = floor( $height * ( $new_width / $width ) );

	      // create a new tempopary image
    	  $tmp_img = imagecreatetruecolor( $new_width, $new_height );
	      // copy and resize old image into new image 
    	  imagecopyresized( $tmp_img, $img, 0, 0, 0, 0, $new_width, $new_height, $width, $height );
	      // save thumbnail into a file
    	  imagepng( $tmp_img, "{$pathToThumbs}{$fname}" );
	    }
		if ( strtolower($info['extension']) == 'gif' ) 
	    {
			//echo "Creating thumbnail for {$fname} <br />";
	       // load image and get image size
		  $img = imagecreatefromgif( "{$pathToImages}{$fname}" );
	      $width = imagesx( $img );
    	  $height = imagesy( $img );
	      // calculate thumbnail size
    	  $new_width = $thumbWidth;
      	  if($width < $height)
	  		{
			  $new_width = 400;
			}
      	  $new_height = floor( $height * ( $new_width / $width ) );
		  
	      // create a new tempopary image
    	  $tmp_img = imagecreatetruecolor( $new_width, $new_height );
	      // copy and resize old image into new image 
    	  imagecopyresized( $tmp_img, $img, 0, 0, 0, 0, $new_width, $new_height, $width, $height );
	      // save thumbnail into a file
    	  imagegif( $tmp_img, "{$pathToThumbs}{$fname}" );
	    }

	 // }
	  // close the directory
	  closedir( $dir );
	}
	function createThumbs( $pathToImages, $pathToThumbs, $thumbWidth, $fname ) 
	{
	  // open the directory
	  $dir = opendir( $pathToImages );
	  // loop through it, looking for any/all JPG files:
	  //while (false !== ($fname = readdir( $dir ))) {
	  // parse path for the extension
	  $info = pathinfo($pathToImages . $fname);
	  // continue only if this is a JPEG image
	  if ( strtolower($info['extension']) == 'jpg' ) 
	    {
			//echo "Creating thumbnail for {$fname} <br />";
	       // load image and get image size
		  $img = imagecreatefromjpeg( "{$pathToImages}{$fname}" );
	      $width = imagesx( $img );
    	  $height = imagesy( $img );
	      // calculate thumbnail size
    	  $new_width = $thumbWidth;
      	  $new_height = floor( $height * ( $thumbWidth / $width ) );
		  if($new_height>127)
		  {
			  $new_height=127;
		  }
		  if($new_height<127)
		  {
			  $new_height=127;
		  }
	      // create a new tempopary image
    	  $tmp_img = imagecreatetruecolor( $new_width, $new_height );
	      // copy and resize old image into new image 
    	  imagecopyresized( $tmp_img, $img, 0, 0, 0, 0, $new_width, $new_height, $width, $height );
	      // save thumbnail into a file
    	  imagejpeg( $tmp_img, "{$pathToThumbs}{$fname}" );
	    }
		if ( strtolower($info['extension']) == 'png' ) 
	    {
			//echo "Creating thumbnail for {$fname} <br />";
	       // load image and get image size
		  $img = imagecreatefrompng( "{$pathToImages}{$fname}" );
	      $width = imagesx( $img );
    	  $height = imagesy( $img );
	      // calculate thumbnail size
    	  $new_width = $thumbWidth;
      	  $new_height = floor( $height * ( $thumbWidth / $width ) );
		  if($new_height>127)
		  {
			  $new_height=127;
		  }
		  if($new_height<127)
		  {
			  $new_height=127;
		  }
	      // create a new tempopary image
    	  $tmp_img = imagecreatetruecolor( $new_width, $new_height );
	      // copy and resize old image into new image 
    	  imagecopyresized( $tmp_img, $img, 0, 0, 0, 0, $new_width, $new_height, $width, $height );
	      // save thumbnail into a file
    	  imagepng( $tmp_img, "{$pathToThumbs}{$fname}" );
	    }
		if ( strtolower($info['extension']) == 'gif' ) 
	    {
			//echo "Creating thumbnail for {$fname} <br />";
	       // load image and get image size
		  $img = imagecreatefromgif( "{$pathToImages}{$fname}" );
	      $width = imagesx( $img );
    	  $height = imagesy( $img );
	      // calculate thumbnail size
    	  $new_width = $thumbWidth;
      	  $new_height = floor( $height * ( $thumbWidth / $width ) );
		  if($new_height>127)
		  {
			  $new_height=127;
		  }
		  if($new_height<127)
		  {
			  $new_height=127;
		  }
	      // create a new tempopary image
    	  $tmp_img = imagecreatetruecolor( $new_width, $new_height );
	      // copy and resize old image into new image 
    	  imagecopyresized( $tmp_img, $img, 0, 0, 0, 0, $new_width, $new_height, $width, $height );
	      // save thumbnail into a file
    	  imagegif( $tmp_img, "{$pathToThumbs}{$fname}" );
	    }

	 // }
	  // close the directory
	  closedir( $dir );
	}
?>