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
	
	//$queryResult = mysqli_query($mysqli, $query);
	 
	$itemsArray = array();
	
	if ($result = $mysqli->query($query)) { 
		
		$finfo = $result->fetch_field_direct(1);
		
		$fieldName = $finfo->name;
		
		while($row =  $result->fetch_array(MYSQLI_BOTH))
		{
			if (strpos($fieldName, 'en') !== false) {

				$currentItem = array("ID" => $row[0],
							  "DescriptionEN" => $row[1],
							  "DescriptionAR" => $row[2]);
							  
				array_push($itemsArray, $currentItem);
			}
			else{
				$currentItem = array("ID" => $row[0],
							  "DescriptionEN" => $row[2],
							  "DescriptionAR" => $row[1]);
							  
				array_push($itemsArray, $currentItem);
			}	
		}
	}
	echo json_encode($itemsArray);
}
else{
	echo "no table name";
}
?>