<?php
	$db = mysqli_connect('34.67.175.21', 'root', 'vrcommencement', 'commencement');

	if (mysqli_connect_errno())
	{
		echo "1: Connection failed"; //error code #1 = failed to connect to db
		exit();
	}

	$username = $_POST["name"];
	$password = $_POST["password"];
	preg_replace("/[^A-Za-z0-9 ]/", '', $username);
	preg_replace("/[^A-Za-z0-9 ]/", '', $password);

	$namecheckquery = "SELECT username FROM users WHERE username='" . $username . "';";
	$namecheck = $db->query($namecheckquery) or die("2: Name check query failed"); //error code #2 = name check query failed

	if (mysqli_num_rows($namecheck) > 0)
	{
		echo "3: Username in use"; //error code #3 = username already in use
		exit();
	}

	//add user to the table
	$salt = "\$5\$rounds=5000\$" . "s3cretkey" . $username . "\$";
	$hash = crypt($password, $salt);

	$insertuserquery = "INSERT INTO users (username, hash, salt) VALUES ('" . $username . "', '" . $hash . "', '" . $salt . "');";
	$db->query($insertuserquery) or die("4: Insert user query failed"); //error code #4 = insert user query failed.

	echo("0");

	$db->close();
?>