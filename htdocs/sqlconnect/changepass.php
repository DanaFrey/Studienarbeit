<?php

	$con = mysqli_connect('localhost', 'root', 'root', 'studienarbeit');

    //check if the connection was successful
    if(mysqli_connect_errno())
    {
        echo "1: Connection failed."; //Error #1: Connection failed.
        exit();
    }

    $username = $_POST['username'];
    $currentPassword = $_POST['currentPassword'];
    $newPassword = $_POST['newPassword'];


	$checkquery = "SELECT username, salt, hash FROM players WHERE username='" . $username . "';";

    $check = $con->query($checkquery);

    //check if the actual password and the current password match
    $info = mysqli_fetch_assoc($check);
    $currentsalt = $info["salt"];
    $currenthash = $info["hash"];

    $changehash = crypt($currentPassword, $currentsalt);
    if($currenthash != $changehash){
    	echo "7: Incorrect password."; //Error #7: Password does not hash to match table hash.
    	exit();
    }

    //change password of the user
    $newhash = crypt($newPassword, $currentsalt);
    $changepasswordquery = "UPDATE players SET hash='" . $newhash . "' WHERE username='" . $username . "';";

    mysqli_query($con, $changepasswordquery) or die("8: Changing password failed."); //Error #8: The password could not be changed.

    echo("0");



?>