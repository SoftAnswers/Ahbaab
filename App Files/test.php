<?php

session_start();
require_once("conn.conf.php");
$userID;

$stmtcheckuser = $dbh->prepare("select * from accounts where username=:id");
$stmtcheckuser->bindParam(':id',$user);
$user = 'nen001';
if ($stmtcheckuser->execute()) 
{
	$result = $stmtcheckuser->fetch(PDO::FETCH_ASSOC);
		
		$userID = $result["account_id"];
		echo $result["password"]."<br/>";
		/*$data = $result["user_image"];

		$a = json_decode($data);
		
		for ($i = 0; $i < count($a); $i++) {
			
			$ImageContents = $a[$i]->{'ImageBytes'};
			$fileName = $a[$i]->{'FileName'};
			//echo "<img src='data:image/jpg;base64, $b' />";
			
			$test = base64_decode($ImageContents);
			
			file_put_contents($fileName.".jpg",$test);
		}
		$im = imagecreatefromstring($test);

		if ($im !== false) {
			header('Content-Type: image/jpeg');
			imagejpeg($im, "uploads/1.jpg");
			imagedestroy($im);
		}
		else
		{
			echo 'An error occurred.';
		}*/	
}


$stmtgetimage = $dbh->prepare("select * from images where account_id=:id");
$stmtgetimage->bindParam(':id',$user);
$user = $userID;
echo $userID;
if ($stmtgetimage->execute()) 
{
$count = $stmtgetimage->rowCount();
print("Deleted $count rows.\n");

  $result = $stmtgetimage->fetch(PDO::FETCH_ASSOC);
while ($row = $stmtgetimage->fetch(PDO::FETCH_COLUMN)) {
    print $row;
}
}
?>