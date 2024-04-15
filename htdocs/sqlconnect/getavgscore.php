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
    $levelcount = $_POST['levelcount'];


	$getidquery = "SELECT id FROM players WHERE username='" . $username . "';";

    $getid = $con->query($getidquery);
    $id_row = mysqli_fetch_assoc($getid);
    $id = $id_row['id'];

    $scoresum = 0;
    $maxlvl = $levelcount;

    for($i = 1; $i <= $levelcount; $i++){
        $requestquery = "SELECT * FROM scores WHERE id='" . $id . "' AND world='" . $world . "' AND level='" . $i . "';";
        $requestresult = $con->query($requestquery);

        if($requestresult->num_rows == 0){
            $maxlvl--;
        }else{
            //if there is an entry, get grade and translate it the corresponding number
            $getgradequery = "SELECT grade FROM scores WHERE id='" . $id . "' AND world='" . $world . "' AND level='" . $i . "';";
            $result = $con->query($getgradequery);
            $row = $result->fetch_assoc();
            $grade = $row["grade"];
            switch ($grade) {
                case 'A':
                    $scoresum = $scoresum + 1;
                    break;
                case 'B':
                    $scoresum = $scoresum + 2;
                    break;
                case 'C':
                    $scoresum = $scoresum + 3;
                    break;
                case 'D':
                    $scoresum = $scoresum + 4;
                    break;
                case 'E':
                    $scoresum = $scoresum + 5;
                    break;
                case 'F':
                    $scoresum = $scoresum + 6;
                    break;
                default: 
                    echo "9: Something went wrong while extracting the grades."; //Error #9: Unknown grade retrieved.
            }
        }
    }
    if($maxlvl != 0){
        $avggradenum = $scoresum / $maxlvl;
        $avggrade = '';

        if($avggradenum >= 1 && $avggradenum <= 1.5){
            $avggrade = 'A';
        }else if($avggradenum > 1.5 && $avggradenum <= 2.5){
            $avggrade = 'B';
        }else if($avggradenum > 2.5 && $avggradenum <= 3.5){
            $avggrade = 'C';
        }else if($avggradenum > 3.5 && $avggradenum <= 4.5){
            $avggrade = 'D';
        }else if($avggradenum > 4.5 && $avggradenum <= 5.5){
            $avggrade = 'E';
        }else if($avggradenum > 5.5 && $avggradenum <= 6){
            $avggrade = 'F';
        }

        echo $avggrade;
    }else{
        echo("0");
    }
?>