<?php		
	require_once("conn.conf.php");
	
    $userId = $_POST['user'];
    $appToken = $_POST['token'];

    $selectExistingUserTokenStatement = $dbh->prepare("SELECT * from `app_firebase_tokens` WHERE account_id=:user");

    $selectExistingUserTokenStatement->bindParam(':user',$userId);

    $selectExistingUserTokenStatement->execute();

    $row = $selectExistingUserTokenStatement->fetch(PDO::FETCH_ASSOC);

    if($row){
        
        $updateAppTokenStatement = $dbh->prepare("UPDATE app_firebase_tokens SET app_firebase_token=:token WHERE account_id=:user");
        
        $updateAppTokenStatement->bindParam(':token',$appToken);
        
        $updateAppTokenStatement->bindParam(':user',$userId);
        
        if($updateAppTokenStatement->execute()){
            echo('success');
        }
        else{
            echo('failed');
        }
    }
    else{
        $addAppTokenStatement = $dbh->prepare("INSERT INTO app_firebase_tokens (account_id,app_firebase_token) VALUES (:user,:token)");
        
        $addAppTokenStatement->bindParam(':user', $userId);
        
        $addAppTokenStatement->bindParam(':token',$appToken);
        
        if($addAppTokenStatement->execute()){
            echo('success');
        }
        else{
            echo('failed');
        }	
    }
?>