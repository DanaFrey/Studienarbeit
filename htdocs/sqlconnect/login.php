<?php

	$con = mysqli_connect('localhost', 'root', 'root', 'studienarbeit');

    //check if the connection was successful
    if(mysqli_connect_errno())
    {
        echo "1: Connection failed."; //Error #1: Connection failed.
        exit();
    }

    $username = $_POST['username'];
    $password = $_POST['password'];


	$namecheckquery = "SELECT username, salt, hash FROM players WHERE username='" . $username . "';";

    //$namecheck = mysqli_query($con, $namecheckquery) or die("2: Name check failed."); //Error #2: Name check failed.
    $namecheck = $con->query($namecheckquery);

    if(mysqli_num_rows($namecheck) == 0){
    	echo "5: There is no such player registered under that name."; //Error #5: No player under that name registered.
    	exit();
    }else if(mysqli_num_rows($namecheck) > 1){
		echo "6: Something went wrong. There are multiple users registered under that name. Please contact support."; //Error #6: Multiple players registered under the same username.
		exit();
    }

    //get log in info from query
    $logininfo = mysqli_fetch_assoc($namecheck);
    $salt = $logininfo["salt"];
    $hash = $logininfo["hash"];

    $loginhash = crypt($password, $salt);
    if($hash != $loginhash){
    	echo "7: Incorrect password."; //Error #7: Password does not hash to match table hash.
    	exit();
    }

    echo "0";


?>