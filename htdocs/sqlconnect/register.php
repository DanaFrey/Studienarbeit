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

    //check if the username already exists in database
    $namecheckquery = "SELECT username FROM players WHERE username='" . $username . "';";

    //$namecheck = mysqli_query($con, $namecheckquery) or die("2: Name check failed."); //Error #2: Name check failed.
    $namecheck = $con->query($namecheckquery);

    if($namecheck->num_rows > 0)
    {
        echo "3: This name already exists."; //Error #3: Username already exists in database, can't register.
        exit();
    }

    //add user to the players table
    $salt = "\$5\$rounds=5000\$" . "gamedevelopment" . $username . "\$";
    $hash = crypt($password, $salt);
    $insertuserquery = "INSERT INTO players (username, hash, salt) VALUES ('" . $username . "', '" . $hash . "', '" . $salt . "');";

    mysqli_query($con, $insertuserquery) or die("4: Insert player query failed."); //Error #4: The player insertion query has failed.

    echo("0");
?>