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
	
	if ($tableName == 'ages') {
		$query = $query ."ORDER BY `age_range` ASC";
	}
	
	$queryResult = mysqli_query($mysqli, $query);
	 
	$itemsArray = array();
	 
	while($row= mysqli_fetch_row($queryResult))
	{
		
		$currentItem = array("ID" => $row[0],
					  "DescriptionEN" => $row[1]);
							 
		array_push($itemsArray, $currentItem);
	}

	echo json_encode($itemsArray);
}
else{
	echo "no table name";
}
?>