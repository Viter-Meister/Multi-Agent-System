uses Robotics, TCPServer;

begin  
  var server := new ServerObj('your IP address', 8888);
  var robot := new Robot('robot1');
  
  // This is just an example
  //
  // server.Send(robot.MoveForward());
  // server.Send(robot.MoveBack());
  // server.Send(robot.TurnLeft());
  // server.Send(robot.TurnRigth());
  
  // Place your code below
  
  server.Start();
end.