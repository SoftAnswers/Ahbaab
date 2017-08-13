<?php
session_start();

if(isset($_POST['message']) || isset($_POST['level'])) {
	$message = $_POST['message'];
	$level = $_POST['level'];
	
	switch (strtolower($level)) {
        case 'error':
            $level='ERROR';
            break;
        case 'info':
            $level='INFO';
            break;
        case 'debug':
            $level='DEBUG';
            break;
        default:
            $level='INFO';
    }
    error_log(date("[Y-m-d H:i:s]")."\t[".$level."]\t".$message."\r\n", 3, "../logs/ahbabLogs.log");
}

?>