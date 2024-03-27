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


	$getidquery = "SELECT id FROM players WHERE username='" . $username . "';";

    $getid = $con->query($getidquery);
    $id_row = mysqli_fetch_assoc($getid);
    $id = $id_row['id'];

    $requestquery = "SELECT * FROM scores WHERE id='" . $id . "' AND world='" . $world . "' AND level='" . $level . "';";
    $requestresult = $con->query($requestquery);

    if($requestresult->num_rows == 0){
        //if there is no entry echo that
        echo("0");
    }else{
        //if there is an entry, get grade
        $getgradequery = "SELECT grade FROM scores WHERE id='" . $id . "' AND world='" . $world . "' AND level='" . $level . "';";
        $result = $con->query($getgradequery);
        $row = $result->fetch_assoc();
        $grade = $row["grade"];
        echo $grade;
    }

?>