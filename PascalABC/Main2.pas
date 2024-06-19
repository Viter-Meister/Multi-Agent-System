uses Robotics;

procedure RotateLeft90(robot: Robot);
begin
  for var i := 1 to 5 do
    robot.TurnLeft();
end;

begin  
  var robot := new Robot('bot');
  
  for var i := 1 to 5 do
    robot.MoveForward();
  
  RotateLeft90(robot);
  
  for var i := 1 to 3 do
    robot.MoveForward();
  
  robot.TurnRight();
  robot.MoveBack();
  
  robot.DoCommand();
end.