<?php
	if(!isset($_SESSION)) 
	{
		session_start();
	}
	if(!isset($_SESSION['userid']))
	{
		header('Location: ' . 'index.php');
	}
	require_once("conn.conf.php");
	include_once("timeout.php");
	$stmtcheckaccount = $dbh->prepare("select username from accounts where account_id =:account");
	$stmtcheckaccount->bindParam(':account',$account);
	$account = $_SESSION['userid'];
	if($stmtcheckaccount->execute())
	{
		$countaccount = $stmtcheckaccount->rowCount();
		if ($countaccount == 0)
		{
			unset($_SESSION['userid']);
			header('Location: ' . 'index.php');
		}
	}

	$stmtcheckpaid = $dbh->prepare("select paid from accounts where account_id = :account");
	$stmtcheckpaid->bindParam(':account',$acc);
	$acc = $_SESSION['userid'];
	if ($stmtcheckpaid->execute())
		{
		$rowcheckpaid = $stmtcheckpaid->fetch();
		if($rowcheckpaid['paid'] == 'N')
			{	
				header('Location: ' . 'pay.php');
		}
	}
	
	$stmtaccount = $dbh->prepare("select * from accounts where account_id=:account");
	$stmtaccount->bindParam(':account',$acc);
	if($stmtaccount->execute())
	{
		$rowaccount = $stmtaccount->fetch();
	}
if (isset($_POST['submit']))
	{
			$uploadform = "modifyaccount.php";
			if($_POST['pass'] == "")
			{
				error("الرجاء إدخال كلمة السر",$uploadform);
			}
			$pattern = "/^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,3})$/i";
			$email = $_POST['mail'];
			if (!preg_match($pattern,$email))
			{
				error("الرجاء إدخال البريد الإلكتروني بشكل صحيح",$uploadform);
			}
			if($_POST['describeyou'] == "")
			{
				error("الرجاء تعبئة خانة أوصف نفسك",$uploadform);
			}
			if($_POST['describeother'] == "")
			{
				error("الرجاء تعبئة خانة أوصف الشريك",$uploadform);
			}
			if($_POST['name'] == "")
			{
				error("الرجاء كتابة الإسم الكامل",$uploadform);
			}
			if($_POST['status'] == "")
			{
				error("الرجاء إختيار الوضع العائلي",$uploadform);
			}
			if($_POST['usagepurpose'] == "")
			{
				error("الرجاء إختيار الهدف من الموقع",$uploadform);
			}
			if($_POST['age'] == "")
			{
				error("الرجاء إختيار الهدف من الموقع",$uploadform);
			}
			if($_POST['origin'] == "")
			{
				error("الرجاء إختيار بلد الأصل",$uploadform);
			}
			if($_POST['current'] == "")
			{
				error("الرجاء إختيار بلد السكن",$uploadform);
			}
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
			$stmt->bindParam(':account',$acc);
			$user = $_POST['user'];
			$pass = $_POST['pass'];
			$mail = $_POST['mail'];
			$name = $_POST['name'];
			$gender = $_POST['gender'];
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
			unset($_SESSION['pass']);
			unset($_SESSION['mail']);
			unset($_SESSION['name']);
			unset($_SESSION['status']);
			unset($_SESSION['eyecolor']);
			unset($_SESSION['haircolor']);
			unset($_SESSION['height']);
			unset($_SESSION['weight']);
			unset($_SESSION['usagepurpose']);
			unset($_SESSION['age']);
			unset($_SESSION['educlevel']);
			unset($_SESSION['origin']);
			unset($_SESSION['current']);
			unset($_SESSION['job']);
			unset($_SESSION['describeyou']);
			unset($_SESSION['describeother']);
			unset($_SESSION['timezone']);
			unset($_SESSION['avaialble']);
			header('Location: ' . 'profile.php');
	}
	function error($error, $location, $seconds = 3)
	{
   	 	header("Refresh: $seconds; URL=\"$location\"");
		$_SESSION['pass'] = $_POST['pass'];
			$_SESSION['mail'] = $_POST['mail'];
			$_SESSION['name'] = $_POST['name'];
			$_SESSION['status'] = $_POST['status'];
			$_SESSION['eyecolor'] = $_POST['eyecolor'];
			$_SESSION['haircolor'] = $_POST['haircolor'];
			$_SESSION['height'] = $_POST['height'];
			$_SESSION['weight'] = $_POST['weight'];
			$_SESSION['usagepurpose'] = $_POST['usagepurpose'];
			$_SESSION['age'] = $_POST['age'];
			$_SESSION['educlevel'] = $_POST['educlevel'];
			$_SESSION['origin'] = $_POST['origin'];
			$_SESSION['current'] = $_POST['current'];
			$_SESSION['job'] = $_POST['job'];
			$_SESSION['describeyou'] = $_POST['describeyou'];
			$_SESSION['describeother'] = $_POST['describeother'];
			$_SESSION['timezone'] = $_POST['timezone'];
			$_SESSION['available'] = $_POST['available'];
		echo '<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link rel="stylesheet" type="text/css" href="css/style.css" />
<title>أحباب - الرئيسية</title>
</head>

<body>
	<div id="pagecontainer">
    	<div id="workarea">
        	<div id="header">
            	<div id="logo">
                	<a href="index.php"><img src="images/logo.png" /></a>
                </div>
                <div id="flags">
                	<img src="images/ar-on.png" /><img src="images/en-off.png" />
                </div>
            </div>
            <div id="searcharea">
				<div id="infosection">
                '.$error.'
                </div>
           	</div>

            <div id="ad">
            		<script async src="//pagead2.googlesyndication.com/pagead/js/adsbygoogle.js"></script>
					<!-- Ahbaab-468by60 -->
					<ins class="adsbygoogle"
			     		style="display:inline-block;width:468px;height:60px;"
			     		data-ad-client="ca-pub-0418112928059716"
			     		data-ad-slot="3638767597"></ins>
					<script>
					(adsbygoogle = window.adsbygoogle || []).push({});
					</script>
            </div>
			<?php include_once("footer.php");  ?>  
        </div>
    </div>
</body>

</html>';
		exit;
	} // end error handler
?>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link rel="stylesheet" type="text/css" href="css/style.css" />
<title>أحباب - الرئيسية</title>
</head>

<body>
	<div id="pagecontainer">
    	<div id="workarea">
        	<?php include_once("header.php"); ?>
            <div id="searcharea" style="height:auto;">
				<div id="infosection" style="height:auto;">
                <?php echo '<a href="profile.php" style="color:#333;">العودة إلى الملف الشخصي</a><br><br>';?>
                <form action="" method="post" style="text-align:right; direction:rtl;">
            		<?php
					
						if(!isset($_SESSION['pass']))
                    		{
                    			echo 'كلمة السر*:<input type="text" name="pass" value = "'.$rowaccount['password'].'" style="width:300px; margin-right:60px;" /><br /><br />';
                    		}
                    		else
                    		{
                    			echo 'كلمة السر*:<input type="text" name="pass" value="'.$_SESSION['pass'].'" style="width:300px; margin-right:60px;" /><br /><br />';
                    		}
					?>
                    <?php
						if(!isset($_SESSION['mail']))
                    		{
                    			echo 'البريد*:<input type="text" name="mail" value = "'.$rowaccount['email'].'" style="width:300px; margin-right:95px;" /><br /><br />';
                    		}
                    		else
                    		{
                    			echo 'البريد*:<input type="text" name="mail" value="'.$_SESSION['mail'].'" style="width:300px; margin-right:95px;" /><br /><br />';
                    		}
					?>
                    <?php
						if(!isset($_SESSION['name']))
                    		{
                    			echo 'الإسم الكامل* :<input type="text" name="name" value = "'.$rowaccount['name'].'" style="width:300px; margin-right:35px;" /><br /><br />';
                    		}
                    		else
                    		{
                    			echo 'الإسم الكامل*:<input type="text" name="name" value="'.$_SESSION['name'].'" style="width:300px; margin-right:35px;" /><br /><br />';
                    		}
					?>
                    <!-- Marital Status Begin-->
                    <?php
						if(!isset($_SESSION['status']))
                    		{
								echo 'الوضع العائلي* :';
								echo '<select name="status" style="margin-right:35px; width:300px;">';
								$stmt = $dbh->prepare("SELECT * FROM marital_status");
									if ($stmt->execute()) 
										{
											while ($row = $stmt->fetch())
												{
														if($row['status_id'] == $rowaccount['status_id'])
														{
															echo '<option value="'.$row['status_id'].'" selected="selected">'.$row['status_desc_ar'].'</option>';		
														}
														else
														{
															echo '<option value="'.$row['status_id'].'">'.$row['status_desc_ar'].'</option>';	
														}
												}
										}
								echo '</select>';
                    			echo '<br /><br />';
                    		}
                    		else
                    		{
                    			echo 'الوضع العائلي* :';
								echo '<select name="status" style="margin-right:35px; width:300px;">';
								$stmt = $dbh->prepare("SELECT * FROM marital_status");
									if ($stmt->execute()) 
										{
											while ($row = $stmt->fetch())
												{
														if ($row['status_id'] == $_SESSION['status'])
															{
																echo '<option value="'.$row['status_id'].'" selected="selected">'.$row['status_desc_ar'].'</option>';		
															}
														else
															{
																echo '<option value="'.$row['status_id'].'" selected="selected">'.$row['status_desc_ar'].'</option>';		
															}
												}
										}
								echo '</select>';
                    			echo '<br /><br />';
                    		}
					?>
                    <!-- Marital Status End-->
                    <!-- Eye Color Begin -->
                    <?php
						if(!isset($_SESSION['eyecolor']))
                    		{
								echo 'لون العين :';
								echo '<select name="eyecolor" style="margin-right:70px; width:300px;">';
								$stmt = $dbh->prepare("SELECT * FROM eye_colors");
									if ($stmt->execute()) 
										{
											while ($row = $stmt->fetch())
												{
														if($row['color_id'] == $rowaccount['eye_color_id'])
														{
															echo '<option value="'.$row['color_id'].'" selected="selected">'.$row['color_desc_ar'].'</option>';																	
														}
														else
														{
															echo '<option value="'.$row['color_id'].'">'.$row['color_desc_ar'].'</option>';		
														}
												}
										}
								echo '</select>';
                    			echo '<br /><br />';
                    		}
                    		else
                    		{
                    			echo 'لون العين :';
								echo '<select name="eyecolor" style="margin-right:70px; width:300px;">';
								$stmt = $dbh->prepare("SELECT * FROM eye_colors");
									if ($stmt->execute()) 
										{
											while ($row = $stmt->fetch())
												{
														if ($row['color_id'] == $_SESSION['eyecolor'])
															{
																echo '<option value="'.$row['color_id'].'" selected="selected">'.$row['color_desc_ar'].'</option>';		
															}
														else
															{
																echo '<option value="'.$row['color_id'].'">'.$row['color_desc_ar'].'</option>';		
															}
												}
										}
								echo '</select>';
                    			echo '<br /><br />';
                    		}
					?>
                    <!-- Eye Color End-->
                    <!-- Hair Color Begin -->
                    <?php
						if(!isset($_SESSION['haircolor']))
                    		{
								echo 'لون الشعر :';
								echo '<select name="haircolor" style="margin-right:65px; width:300px;">';
								$stmt = $dbh->prepare("SELECT * FROM hair_color");
									if ($stmt->execute()) 
										{
											while ($row = $stmt->fetch())
												{
														if($row['color_id'] == $rowaccount['hair_color_id'])
														{
															echo '<option value="'.$row['color_id'].'" selected="selected">'.$row['color_desc_ar'].'</option>';																	
														}
														else
														{
															echo '<option value="'.$row['color_id'].'">'.$row['color_desc_ar'].'</option>';																	
														}
												}
										}
								echo '</select>';
                    			echo '<br /><br />';
                    		}
                    		else
                    		{
                    			echo 'لون الشعر :';
								echo '<select name="haircolor" style="margin-right:65px; width:300px;">';
								$stmt = $dbh->prepare("SELECT * FROM hair_color");
									if ($stmt->execute()) 
										{
											while ($row = $stmt->fetch())
												{
														if ($row['color_id'] == $_SESSION['haircolor'])
															{
																echo '<option value="'.$row['color_id'].'" selected="selected">'.$row['color_desc_ar'].'</option>';		
															}
														else
															{
																echo '<option value="'.$row['color_id'].'">'.$row['color_desc_ar'].'</option>';		
															}
												}
										}
								echo '</select>';
                    			echo '<br /><br />';
                    		}
					?>
                    <!-- Hair Color End-->
                    <!-- Height Begin -->
                    <?php
						if(!isset($_SESSION['height']))
                    		{
								echo 'الطول :';
								echo '<select name="height" style="margin-right:95px; width:300px;">';
								$stmt = $dbh->prepare("SELECT * FROM heights");
									if ($stmt->execute()) 
										{
											while ($row = $stmt->fetch())
												{
														if($row['height_id'] == $rowaccount['height_id'])
														{
															echo '<option value="'.$row['height_id'].'" selected="selected">'.$row['height_desc_ar'].'</option>';
														}
														else
														{
															echo '<option value="'.$row['height_id'].'">'.$row['height_desc_ar'].'</option>';
														}
												}
										}
								echo '</select>';
                    			echo '<br /><br />';
                    		}
                    		else
                    		{
                    			echo 'الطول :';
								echo '<select name="height" style="margin-right:95px; width:300px;">';
								$stmt = $dbh->prepare("SELECT * FROM heights");
									if ($stmt->execute()) 
										{
											while ($row = $stmt->fetch())
												{
														if ($row['height_id'] == $_SESSION['height'])
															{
																echo '<option value="'.$row['height_id'].'" selected="selected">'.$row['height_desc_ar'].'</option>';		
															}
														else
															{
																echo '<option value="'.$row['height_id'].'">'.$row['height_desc_ar'].'</option>';		
															}
												}
										}
								echo '</select>';
                    			echo '<br /><br />';
                    		}
					?>
                    <!-- Height End--> 
                    <!-- Weight Begin -->
                    <?php
						if(!isset($_SESSION['weight']))
                    		{
								echo 'الوزن :';
								echo '<select name="weight" style="margin-right:100px; width:300px;">';
								$stmt = $dbh->prepare("SELECT * FROM weights");
									if ($stmt->execute()) 
										{
											while ($row = $stmt->fetch())
												{
														if($row['weight_id'] == $rowaccount['weight_id'])
														{
															echo '<option value="'.$row['weight_id'].'" selected="selected">'.$row['weight_desc_ar'].'</option>';		
														}
														else
														{
															echo '<option value="'.$row['weight_id'].'">'.$row['weight_desc_ar'].'</option>';		
														}
												}
										}
								echo '</select>';
                    			echo '<br /><br />';
                    		}
                    		else
                    		{
                    			echo 'الوزن :';
								echo '<select name="weight" style="margin-right:100px; width:300px;">';
								$stmt = $dbh->prepare("SELECT * FROM weights");
									if ($stmt->execute()) 
										{
											while ($row = $stmt->fetch())
												{
														if ($row['weight_id'] == $_SESSION['weight'])
															{
																echo '<option value="'.$row['weight_id'].'" selected="selected">'.$row['weight_desc_ar'].'</option>';		
															}
														else
															{
																echo '<option value="'.$row['weight_id'].'">'.$row['weight_desc_en'].'</option>';		
															}
												}
										}
								echo '</select>';
                    			echo '<br /><br />';
                    		}
					?>
                    <!-- Weight End--> 
                    <!-- Usage Purpose Begin -->
                    <?php
						if(!isset($_SESSION['usagepurpose']))
                    		{
								echo 'الهدف من الموقع* :';
								echo '<select name="usagepurpose" style="margin-right:10px; width:300px;">';
								$stmt = $dbh->prepare("SELECT * FROM usage_purpose");
									if ($stmt->execute()) 
										{
											while ($row = $stmt->fetch())
												{
														if($row['purpose_id'] == $rowaccount['usage_purpose_id'])
														{
															echo '<option value="'.$row['purpose_id'].'" selected="selected">'.$row['purpose_desc_ar'].'</option>';			
														}
														else
														{
															echo '<option value="'.$row['purpose_id'].'">'.$row['purpose_desc_ar'].'</option>';		
														}
												}
										}
								echo '</select>';
                    			echo '<br /><br />';
                    		}
                    		else
                    		{
                    			echo 'الهدف من الموقع* :';
								echo '<select name="usagepurpose" style="margin-right:10px; width:300px;">';
								$stmt = $dbh->prepare("SELECT * FROM usage_purpose");
									if ($stmt->execute()) 
										{
											while ($row = $stmt->fetch())
												{
														if ($row['purpose_id'] == $_SESSION['usagepurpose'])
															{
																echo '<option value="'.$row['purpose_id'].'" selected="selected">'.$row['purpose_desc_ar'].'</option>';		
															}
														else
															{
																echo '<option value="'.$row['purpose_id'].'">'.$row['purpose_desc_ar'].'</option>';		
															}
												}
										}
								echo '</select>';
                    			echo '<br /><br />';
                    		}
					?>
                    <!-- Usage Purpose End--> 
                   	<!-- Age Begin -->
                    <?php
						if(!isset($_SESSION['age']))
                    		{
								echo 'العمر* :';
								echo '<select name="age" style="margin-right:90px; width:300px;">';
								$stmt = $dbh->prepare("SELECT * FROM ages");
									if ($stmt->execute()) 
										{
											while ($row = $stmt->fetch())
												{
														if($row['age_id'] == $rowaccount['age_id'])
														{
															echo '<option value="'.$row['age_id'].'" selected="selected">'.$row['age_range'].'</option>';		
														}
														else
														{
															echo '<option value="'.$row['age_id'].'">'.$row['age_range'].'</option>';		
														}
												}
										}
								echo '</select>';
                    			echo '<br /><br />';
                    		}
                    		else
                    		{
                    			echo '*العمر :';
								echo '<select name="age" style="margin-right:90px; width:300px;">';
								$stmt = $dbh->prepare("SELECT * FROM ages");
									if ($stmt->execute()) 
										{
											while ($row = $stmt->fetch())
												{
														if ($row['age_id'] == $_SESSION['age'])
															{
																echo '<option value="'.$row['age_id'].'" selected="selected">'.$row['age_range'].'</option>';		
															}
														else
															{
																echo '<option value="'.$row['age_id'].'">'.$row['age_range'].'</option>';		
															}
												}
										}
								echo '</select>';
                    			echo '<br /><br />';
                    		}
					?>
                    <!-- Age End-->
                   	<!-- Educational Level Begin -->
                    <?php
						if(!isset($_SESSION['educlevel']))
                    		{
								echo 'المستوى العلمي :';
								echo '<select name="educlevel" style="margin-right:18px; width:300px;">';
								$stmt = $dbh->prepare("SELECT * FROM educ_levels");
									if ($stmt->execute()) 
										{
											while ($row = $stmt->fetch())
												{
														if($row['educ_level_id'] == $rowaccount['educ_level_id'])
														{
															echo '<option value="'.$row['educ_level_id'].'" selected="selected">'.$row['educ_level_ar'].'</option>';		
														}
														else
														{
															echo '<option value="'.$row['educ_level_id'].'">'.$row['educ_level_ar'].'</option>';		
														}
												}
										}
								echo '</select>';
                    			echo '<br /><br />';
                    		}
                    		else
                    		{
                    			echo 'المستوى العلمي :';
								echo '<select name="educlevel" style="margin-right:18px; width:300px;">';
								$stmt = $dbh->prepare("SELECT * FROM educ_levels");
									if ($stmt->execute()) 
										{
											while ($row = $stmt->fetch())
												{
														if ($row['educ_level_id'] == $_SESSION['educlevel'])
															{
																echo '<option value="'.$row['educ_level_id'].'" selected="selected">'.$row['educ_level_ar'].'</option>';		
															}
														else
															{
																echo '<option value="'.$row['educ_level_id'].'">'.$row['educ_level_ar'].'</option>';		
															}
												}
										}
								echo '</select>';
                    			echo '<br /><br />';
                    		}
					?>
                    <!-- Educational Level End-->
                    <!-- Origin Country Begin -->
                    <?php
						if(!isset($_SESSION['origin']))
                    		{
								echo 'بلد الأصل* :';
								echo '<select name="origin" style="width:300px; margin-right:63px;">';
								$stmt = $dbh->prepare("SELECT * FROM countries");
									if ($stmt->execute()) 
										{
											while ($row = $stmt->fetch())
												{
														if($row['country_id'] == $rowaccount['origin_ctry_id'])
														{
															echo '<option value="'.$row['country_id'].'" selected="selected">'.$row['country_name_ar'].'</option>';		
														}
														else
														{
															echo '<option value="'.$row['country_id'].'">'.$row['country_name_ar'].'</option>';		
														}
												}
										}
								echo '</select>';
                    			echo '<br /><br />';
                    		}
                    		else
                    		{
                    			echo 'بلد الأصل* :';
								echo '<select name="origin" style="width:300px; margin-right:63px;">';
								$stmt = $dbh->prepare("SELECT * FROM countries");
									if ($stmt->execute()) 
										{
											while ($row = $stmt->fetch())
												{
														if ($row['country_id'] == $_SESSION['origin'])
															{
																echo '<option value="'.$row['country_id'].'" selected="selected">'.$row['country_name_ar'].'</option>';		
															}
														else
															{
																echo '<option value="'.$row['country_id'].'">'.$row['country_name_ar'].'</option>';		
															}
												}
										}
								echo '</select>';
                    			echo '<br /><br />';
                    		}
					?>
                    <!-- Origin Country End-->   
                    <!-- Current Country Begin -->
                    <?php
						if(!isset($_SESSION['current']))
                    		{
								echo 'بلد السكن* :';
								echo '<select name="current" style="width:300px; margin-right:55px;">';
								$stmt = $dbh->prepare("SELECT * FROM countries");
									if ($stmt->execute()) 
										{
											while ($row = $stmt->fetch())
												{
														if($row['country_id'] == $rowaccount['current_ctry_id'])
														{
															echo '<option value="'.$row['country_id'].'" selected="selected">'.$row['country_name_ar'].'</option>';		
														}
														else
														{
															echo '<option value="'.$row['country_id'].'">'.$row['country_name_ar'].'</option>';		
														}
												}
										}
								echo '</select>';
                    			echo '<br /><br />';
                    		}
                    		else
                    		{
                    			echo 'بلد السكن* :';
								echo '<select name="current" style="width:300px; margin-right:55px;">';
								$stmt = $dbh->prepare("SELECT * FROM countries");
									if ($stmt->execute()) 
										{
											while ($row = $stmt->fetch())
												{
														if ($row['country_id'] == $_SESSION['current'])
															{
																echo '<option value="'.$row['country_id'].'" selected="selected">'.$row['country_name_ar'].'</option>';		
															}
														else
															{
																echo '<option value="'.$row['country_id'].'">'.$row['country_name_ar'].'</option>';		
															}
												}
										}
								echo '</select>';
                    			echo '<br /><br />';
                    		}
					?>
                    <!-- Current Country End-->   
                    <!-- Job Begin -->
                    <?php
						if(!isset($_SESSION['job']))
                    		{
								echo 'الوظيفة :';
								echo '<select name="job" style="margin-right:85px; width:300px;">';
								$stmt = $dbh->prepare("SELECT * FROM jobs");
									if ($stmt->execute()) 
										{
											while ($row = $stmt->fetch())
												{
														if($row['job_id'] == $rowaccount['job_id'])
														{
															echo '<option value="'.$row['job_id'].'" selected= "selected">'.$row['job_desc_ar'].'</option>';		
														}
														else
														{
															echo '<option value="'.$row['job_id'].'">'.$row['job_desc_ar'].'</option>';		
														}
												}
										}
								echo '</select>';
                    			echo '<br /><br />';
                    		}
                    		else
                    		{
                    			echo 'الوظيفة :';
								echo '<select name="job" style="margin-right:85px; width:300px;">';
								$stmt = $dbh->prepare("SELECT * FROM jobs");
									if ($stmt->execute()) 
										{
											while ($row = $stmt->fetch())
												{
														if ($row['job_id'] == $_SESSION['job'])
															{
																echo '<option value="'.$row['job_id'].'" selected="selected">'.$row['job_desc_ar'].'</option>';		
															}
														else
															{
																echo '<option value="'.$row['job_id'].'">'.$row['job_desc_ar'].'</option>';		
															}
												}
										}
								echo '</select>';
                    			echo '<br /><br />';
                    		}
					?>
                    <!-- Job End-->                                                                                                                          
                    <!-- Begin Describe You-->   
					<?php
						if(!isset($_SESSION['describeyou']))
                    		{
                    			echo 'أوصف نفسك* :<textarea name="describeyou" rows=3 cols=40 style="margin-right:40px;">'.$rowaccount['describe_you'].'</textarea><br /><br />';
                    		}
                    		else
                    		{
                    			echo 'أوصف نفسك* :<textarea name="describeyou" rows=3 cols=40 style="margin-right:40px;">'.$_SESSION['describeyou'].'</textarea><br /><br />';
                    		}
					?>    
                    <!-- End Describe You--> 
					<!-- Begin Describe Other-->   
					<?php
						if(!isset($_SESSION['describeother']))
                    		{
                    			echo 'أوصف الشريك* :<textarea name="describeother" rows=3 cols=40 style="margin-right:33px;">'.$rowaccount['describe_others'].'</textarea><br /><br />';
                    		}
                    		else
                    		{
                    			echo 'أوصف الشريك* :<textarea name="describeother" rows=3 cols=40 style="margin-right:33px;">'.$_SESSION['describeother'].'</textarea><br /><br />';
                    		}
					?>    
                    <!-- End Describe You-->          
                    <!-- Time Zone Begin -->
                    <?php
						if(!isset($_SESSION['timezone']))
                    		{
								echo 'توقيت :';
								echo '<select name="timezone" style="margin-right:98px; width:300px;">';
								$stmt = $dbh->prepare("SELECT * FROM timezones");
									if ($stmt->execute()) 
										{
											while ($row = $stmt->fetch())
												{
														if($row['timezone_id'] == $rowaccount['timezone_id'])
														{
															echo '<option value="'.$row['timezone_id'].'" selected="selected">'.$row['timezone_desc_ar'].'</option>';		
														}
														else
														{
															echo '<option value="'.$row['timezone_id'].'">'.$row['timezone_desc_ar'].'</option>';			
														}
														
												}
										}
								echo '</select>';
                    			echo '<br /><br />';
                    		}
                    		else
                    		{
                    			echo 'توقيت :';
								echo '<select name="timezone" style="margin-right:98px; width:300px;">';
								$stmt = $dbh->prepare("SELECT * FROM timezones");
									if ($stmt->execute()) 
										{
											while ($row = $stmt->fetch())
												{
														if ($row['timezone_id'] == $_SESSION['timezone'])
															{
																echo '<option value="'.$row['timezone_id'].'" selected="selected">'.$row['timezone_desc_ar'].'</option>';		
															}
														else
															{
																echo '<option value="'.$row['timezone_id'].'">'.$row['timezone_desc_ar'].'</option>';		
															}
												}
										}
								echo '</select>';
                    			echo '<br /><br />';
                    		}
					?>
                    <!-- Time Zone End-->   
                    <!-- Available Time Begin -->
                    <?php
						if(!isset($_SESSION['available']))
                    		{
								echo 'الوقت للإتصال :';
								echo '<select name="available" style="margin-right:47px; width:300px;">';
								$stmt = $dbh->prepare("SELECT * FROM available_time");
									if ($stmt->execute()) 
										{
											while ($row = $stmt->fetch())
												{
														if($row['time_frame_id'] == $rowaccount['time_frame_id'])
														{
															echo '<option value="'.$row['time_frame_id'].'" selected="selected">'.$row['time_frame_desc'].'</option>';		
														}
														else
														{
															echo '<option value="'.$row['time_frame_id'].'">'.$row['time_frame_desc'].'</option>';			
														}
												}
										}
								echo '</select>';
                    			echo '<br /><br />';
                    		}
                    		else
                    		{
                    			echo 'الوقت للإتصال :';
								echo '<select name="available" style="margin-right:47px; width:300px;">';
								
								$stmt = $dbh->prepare("SELECT * FROM available_time");
									if ($stmt->execute()) 
										{
											while ($row = $stmt->fetch())
												{
														if ($row['time_frame_id'] == $_SESSION['avaialable'])
															{
																echo '<option value="'.$row['time_frame_id'].'" selected="selected">'.$row['time_frame_desc'].'</option>';		
															}
														else
															{
																echo '<option value="'.$row['time_frame_id'].'">'.$row['time_frame_desc'].'</option>';		
															}
												}
										}
								echo '</select>';
                    			echo '<br /><br />';
                    		}
					?>
                    <br />
                    <!-- Available Time End-->
                    <div class="separator">
                    </div>
                    <br />
                    إضغط هنا: <input type="submit" name="submit" value="للتعديل" style="width:100px; font-family:Tahoma, Geneva, sans-serif; font-size:14px; font-weight:bold; color:#666;"  />
            	</form>
                </div>
           	</div>

            <div id="ad">
            		<script async src="//pagead2.googlesyndication.com/pagead/js/adsbygoogle.js"></script>
					<!-- Ahbaab-468by60 -->
					<ins class="adsbygoogle"
			     		style="display:inline-block;width:468px;height:60px;"
			     		data-ad-client="ca-pub-0418112928059716"
			     		data-ad-slot="3638767597"></ins>
					<script>
					(adsbygoogle = window.adsbygoogle || []).push({});
					</script>
            </div>
			<?php include_once("footer.php");  ?>  
        </div>
    </div>
</body>

</html>