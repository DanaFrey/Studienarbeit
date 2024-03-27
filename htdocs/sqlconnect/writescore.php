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
    $grade = $_POST['grade'];


	$getidquery = "SELECT id FROM players WHERE username='" . $username . "';";

    $getid = $con->query($getidquery);
    $id_row = mysqli_fetch_assoc($getid);
    $id = $id_row['id'];

    $requestquery = "SELECT * FROM scores WHERE id='" . $id . "' AND world='" . $world . "' AND level='" . $level . "';";
    $requestresult = $con->query($requestquery);

    if($requestresult->num_rows == 0){
        //if there is no entry yet, create an entry
        $insertentryquery = "INSERT INTO scores (id, world, level, grade) VALUES ('" . $id . "', '" . $world . "', '" . $level . "', '" . $grade . "');";
        mysqli_query($con, $insertentryquery) or die("9: Writing entry in database failed."); //Error #9: The entry could not be written into the scores table.
    }else{
        $getcurrentggradequery = "SELECT grade FROM scores WHERE id='" . $id . "' AND world='" . $world . "' AND level='" . $level . "';";
        $getcurrgrade = $con->query($getcurrentggradequery);
        $currgrade_row = mysqli_fetch_assoc($getcurrgrade);
        $currgrade = $currgrade_row['grade'];
        $newgrade = $grade;
        if(($newgrade == "A" && ($currgrade == "B") || ($currgrade == "C")|| ($currgrade == "D")|| ($currgrade == "E")|| ($currgrade == "F")) || ($newgrade == "B" && ($currgrade == "C") || ($currgrade == "D")|| ($currgrade == "E")|| ($currgrade == "F")) || ($newgrade == "C" && ($currgrade == "D") || ($currgrade == "E")|| ($currgrade == "F")) || ($newgrade == "D" && ($currgrade == "E") || ($currgrade == "F")) || ($newgrade == "E" && $currgrade == "F")){
            $updateentryquery = "UPDATE scores SET grade='" . $grade . "' WHERE id='" . $id . "';";
            mysqli_query($con, $updateentryquery) or die("10: Updating score entry failed."); //Error #10: The score entry could not be updated.
        }
    }

    echo("0");

?>