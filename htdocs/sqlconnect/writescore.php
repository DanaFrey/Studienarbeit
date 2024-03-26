<?php

	$con = mysqli_connect('localhost', 'root', 'root', 'studienarbeit');

    //check if the connection was successful
    if(mysqli_connect_errno())
    {
        echo "1: Connection failed."; //Error #1: Connection failed.
        exit();
    }

    $username = $_POST['username'];
    $world = $_POST['world'];
    $level = $_POST['level'];
    $score = $_POST['score'];


	$getidquery = "SELECT id FROM players WHERE username='" . $username . "';";

    $getid = $con->query($getidquery);
    $id_row = mysqli_fetch_assoc($getid);
    $id = $id_row['id'];

    $requestquery = "SELECT * FROM scores WHERE id='" . $id . "' AND world='" . $world . "' AND level='" . $level . "';";
    $requestresult = $con->query($requestquery);

    if($requestresult->num_rows == 0){
        //if there is no entry yet, create an entry
        $insertentryquery = "INSERT INTO scores (id, world, level, score) VALUES ('" . $id . "', '" . $world . "', '" . $level . "', '" . $score . "');";
        mysqli_query($con, $insertentryquery) or die("9: Writing entry in database failed."); //Error #9: The entry could not be written into the scores table.
    }else{
        $updateentryquery = "UPDATE scores SET score='" . $score . "' WHERE id='" . $id . "';";
        mysqli_query($con, $updateentryquery) or die("10: Updating score entry failed."); //Error #10: The score entry could not be updated.
    }

    echo("0");

?>