uses Robotics;

begin  
  var robot1 := new Robot('bot_1');
  
  robot1.DiffeDrive.SetAngularSpeed(10.1);
  var prop := robot1.DiffeDrive.AngularSpeed;
  Console.WriteLine($'Угловая скорость: {prop}');
  robot1.DoCommand();
end.