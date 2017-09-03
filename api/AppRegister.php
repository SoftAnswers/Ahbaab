<?php	
	session_start();
	require_once("conn.conf.php");
//if (isset($_POST['submit']))
	//{
			$uploadform = "register.php";
			if($_POST['user'] == "")
			{
				echo "الرجاء إدخال إسم المستخدم";
			}
			mb_regex_encoding('UTF-8');
			$text = $_POST['user'];
			if(mb_ereg('[\x{0600}-\x{06FF}]', $text)) // arabic range
				//if(mb_ereg('[\x{0590}-\x{05FF}]', $text)) // hebrew range
				{
				if (strlen($_POST['user']) <10)
				{
					echo "يجب على إسم المستخدم أن يكون أكثر من خمسة أحرف";
				}
					
				}
			else
			{
				if (strlen($_POST['user']) <5)
				{
					echo "يجب على إسم المستخدم أن يكون أكثر من خمسة أحرف";
				}
			}
			if($_POST['pass'] == "")
			{
				echo "الرجاء إدخال كلمة السر";
			}
			$pattern = "/^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,3})$/i";
			$email = $_POST['mail'];
			if (!preg_match($pattern,$email))
			{
				echo "الرجاء إدخال البريد الإلكتروني بشكل صحيح";
			}
			if(!isset($_POST['gender']))
			{
				echo "الرجاء إختيار الجنس";
			}
			if($_POST['describeyou'] == "")
			{
				echo "الرجاء تعبئة خانة أوصف نفسك";
			}
			if($_POST['describeother'] == "")
			{
				echo "الرجاء تعبئة خانة أوصف الشريك";
			}
			if($_POST['name'] == "")
			{
				echo "الرجاء كتابة الإسم الكامل";
			}
			if($_POST['status'] == "0")
			{
				echo "الرجاء إختيار الوضع العائلي";
			}
			if($_POST['usagepurpose'] == "0")
			{
				echo "الرجاء إختيار الهدف من الموقع";
			}
			if($_POST['age'] == "0")
			{
				echo "الرجاء إختيار الهدف من الموقع";
			}
			if($_POST['origin'] == "0")
			{
				echo "الرجاء إختيار بلد الأصل";
			}
			if($_POST['current'] == "0")
			{
				echo "الرجاء إختيار بلد السكن";
			}
			if(!isset($_POST['accept']))
			{
				echo "عليك أن توافق على سياسة الإستخدام وشروط الخصوصية المنصوصة في هذا الموقع";
			}
			$stmtcheck = $dbh->prepare("select account_id from accounts where email=:mail");
			$stmtcheck->bindParam(':mail',$mail);
			$mail = $_POST['mail'];
			if ($stmtcheck->execute()) 
				{
					$count = 0;//$stmtcheck->dataCount();
					if($count != 0)
					{
						echo " إن هذا البريد مستعمل ، الرجاء إدخال بريد إلكتروني آخر";
					}
				}
			$stmtcheckuser = $dbh->prepare("select account_id from accounts where username=:username");
			$stmtcheckuser->bindParam(':username',$user);
			$user = $_POST['user'];
			if ($stmtcheckuser->execute()) 
			{
				$countuser =0;// $stmtcheckuser->dataCount();
				if($countuser != 0)
				{
					echo " إن هذا الإسم للمستخدم مستعمل ، الرجاء إدخال إسم آخر";
				}
			}
			$stmt = $dbh->prepare("INSERT INTO accounts (username,password,email,name,gender,status_id,IP,last_active_date,created_on,eye_color_id,hair_color_id,height_id,weight_id,usage_purpose_id,age_id,educ_level_id,origin_ctry_id,current_ctry_id,job_id,describe_you,describe_others,phone_number,paid,visit_count_to,visit_count_from,interests_to,interests_from,blocks_to,blocks_from,logins,active,time_frame_id,paid_begin,paid_end,account_status,timezone_id) VALUES (:user,:pass,:mail,:name,:gender,:status,:IP,:lastactive,:createdon,:eyecolor,:haircolor,:height,:weight,:usagepurpose,:age,:educlevel,:origin,:current,:job,:describeyou,:describeother,:phone,:paid,:visitto,:visitfrom,:interestto,:interestfrom,:blocksto,:blocksfrom,:logins,:active,:timeframe,:paidbegin,:paidend,:accountstatus,:timezone)");
			$stmt->bindParam(':user', $user);
			$stmt->bindParam(':pass',$pass);
			$stmt->bindParam(':mail',$mail);
			$stmt->bindParam(':name',$name);
			$stmt->bindParam(':gender',$gender);
			$stmt->bindParam(':status',$status);
			$stmt->bindParam(':IP',$clientip);
			$stmt->bindParam(':lastactive',$lastactive);
			$stmt->bindParam(':createdon', $createdon);
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
			$stmt->bindParam(':phone', $phone);
			$stmt->bindParam(':paid', $paid);
			$stmt->bindParam(':visitto', $visitto);
			$stmt->bindParam(':visitfrom', $visitfrom);
			$stmt->bindParam(':interestto', $interestto);
			$stmt->bindParam(':interestfrom', $interestfrom);
			$stmt->bindParam(':blocksto', $blocksto);
			$stmt->bindParam(':blocksfrom', $blocksfrom);
			$stmt->bindParam(':logins', $logins);
			$stmt->bindParam(':active', $active);
			$stmt->bindParam(':timeframe', $timeframe);
			$stmt->bindParam(':paidbegin', $paidbegin);
			$stmt->bindParam(':paidend', $paidend);
			$stmt->bindParam(':accountstatus', $accountstatus);
			$stmt->bindParam(':timezone', $timezone);
			$user = $_POST['user'];
			$pass = $_POST['pass'];
			$mail = $_POST['mail'];
			$name = $_POST['name'];
			$gender = $_POST['gender'];
			$status = $_POST['status'];
			$clientip = $_SERVER['REMOTE_ADDR'];
			$lastactive = date('Y-m-d');
			$createdon = date('Y-m-d');
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
			$phone = "";
			if ($gender == "M")
			{
				$paid = "N";
			}
			if($gender == "F")
			{
				$paid = "Y";
			}
			$visitto = 0;
			$visitfrom = 0;
			$interestto = 0;
			$interestfrom =0;
			$blocksto = 0;
			$blocksfrom = 0;
			$logins = 1;
			$active = 1;
			$timeframe = $_POST['available'];
			$paidbegin = date("1988-01-01");
			$paidend = date("1988-01-01");
			$accountstatus = "P";
			$timezone = $_POST['timezone'];
						
			$stmt->execute();
			$lastid = $dbh->lastInsertId();
			$aWay = $_POST['way'];
			//$aTextBox = $_POST['wayval'];
			
			$img = $_POST["Images"];
			
			$images = json_decode($img);
			//echo $lastid;
		for ($i = 0; $i < count($images); $i++) {
			
			$imageContents = $images[$i]->{'ImageBytes'};
			
			$fileName = $images[$i]->{'FileName'};
			$dir = "../uimg/FullSize/";
			$decodedImageContents = base64_decode($imageContents);
			
			file_force_contents('../uimg/FullSize/'.$fileName.".jpg",$decodedImageContents);
			
			createBig("../uimg/FullSize/","../uimg/usized/",600,$fileName.".jpg");
			createThumbs("../uimg/FullSize/","../uimg/Thumbs/",127,$fileName.".jpg");
			$stmtinsertimage = $dbh->prepare("insert into images (image_name,account_id,promoted,is_profile,image_status,promoted_banner) values (:name,:account,'N','N','P','N')");
			$stmtinsertimage->bindParam(':name',$fileName);
			$stmtinsertimage->bindParam(':account',$lastid);
			$stmtinsertimage->execute();
		}
			
		if(!empty($aWay)) 
		{
			$N = count($aWay);
			$contactWay = json_decode($aWay);
			for($i=0; $i < $N; $i++)
			{
				if($gender == "M")
				{
					$stmtinsertway = $dbh->prepare("insert into contact_preferences (account_id, way_id, way_value, status) values (:acc,:way,:value,:status)");
					$stmtinsertway->bindParam(':acc',$lastid);
					$stmtinsertway->bindParam(':way',$way);
					$stmtinsertway->bindParam(':value',$value);
					$stmtinsertway->bindParam(':status',$status);
					$way = $contactWay[$i]->{'way_id'};
					$value = $contactWay[$i]->{'way_value'};
					$status ='A';
					$stmtinsertway->execute();
				}
				else
				{
					$stmtinsertway = $dbh->prepare("insert into contact_preferences (account_id,way_id,way_value,status) values (:acc,:way,:value,:status)");
					$stmtinsertway->bindParam(':acc',$lastid);
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
			$to = $mail;
			$subject = "أهلاً بكم في موقع أحباب"; 
			$email = "info@ahbaab.com" ; 
			$fullname = "موقع أحباب";
			$body = '<html><head></head><body style="direction:rtl; text-align:right;" ><div style="direction:rtl; text-align:right;">
السلام عليكم		<br>
تم قبول طلبكم في موقع أحباب <a href="http://www.ahbaab.com">www.ahbaab.com</a>  <br>

يمكنك ادخال اسم المستخدم وكلمة السر والدخول الى حسابك <br>

يمكنكم الدخول الى الموقع عبر هذا الرابط <a href="http://www.ahbaab.com">www.ahbaab.com</a>  <br>
في حال واجهنكم أية صعوبة في الدخول يمكنكم الضغط على الرابط الثاني <a href="http://www.ahbaab.net"> www.ahbaab.net</a><br><br>
موقع أحباب يتمتع بتقنيه عالية الجودة من حيث الصور وعمليه البحث وطرق التواصل مع الاعضاء وكما ان الموقع يقدم الكثير من الخدمات للباحثين عن شريك العمر. <br>

ان ادارة موقع أحباب تتمنى لكم كل التوفيق كما اننا نتمنى لكم اطيب الاوقات وانتم تتصفحون موقعنا <br>


________________________________<br>


يصلك هذا الايميل لانك احد مشاركي موقع أحباب <a href="http://www.ahbaab.com">www.ahbaab.com</a>  <br>
<img src="http://www.ahbaab.com/images/logoahbab.png"></div></body></html>
';
			$message = '' .$fullname.' - '. $body; 
			$headers  = 'MIME-Version: 1.0' . "\r\n";
			$headers .= 'Content-type: text/html; charset=utf-8' . "\r\n";
			$headers .= "Return-Path: info@ahbaab.com \r\n"; 
			$headers .= "From: $email"; 
			//$sent = mail($to, $subject, $message, $headers) ; 
			$userArray = array();			
			$stmtgetlastinserted = $dbh->prepare("Select * from accounts where account_id=:id");
			$stmtgetlastinserted->bindParam(':id',$accountid);
			$accountid = $lastid;
			if($stmtgetlastinserted->execute())
			{
				$data = $stmtgetlastinserted->fetch(PDO::FETCH_ASSOC);
				//$data = $allData[0];
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
					"TimeZoneId" => $data["timezone_id"]
				);
				
				array_push($userArray,$currentUser);
			}
			echo json_encode($userArray);
	//}
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
	function watermarkImage ($SourceFile, $WaterMarkText, $DestinationFile) { 
   list($width, $height) = getimagesize($SourceFile);
   $image_p = imagecreatetruecolor($width, $height);
   $image = imagecreatefromjpeg($SourceFile);
   imagecopyresampled($image_p, $image, 0, 0, 0, 0, $width, $height, $width, $height); 
   $black = imagecolorallocate($image_p, 255, 255, 255);
   $font = '../ahbabcons/fontwatermark/arial.ttf';
   $font_size = 14; 
   imagettftext($image_p, $font_size, 0, 30, $height - 50, $black, $font, $WaterMarkText);
   if ($DestinationFile<>'') {
      imagejpeg ($image_p, $DestinationFile, 100); 
   } else {
      header('Content-Type: image/jpeg');
      imagejpeg($image_p, null, 100);
   };
   imagedestroy($image); 
   imagedestroy($image_p); 
};
?>
