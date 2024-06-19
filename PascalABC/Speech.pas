uses Microsoft.Speech;
uses Microsoft.Speech.Synthesis;
uses Microsoft.Speech.Recognition;
uses System.Globalization;
uses System.Threading;
uses Robotics, TCPServer;
{$reference Microsoft.Speech.dll}
{$reference System.Threading.dll}

var completed : ManualResetEvent;
var server := new ServerObj('192.168.31.132', 8888);
var robot := new Robot('robot1');

procedure speechEngine_SpeechRecognized(sender: object; e: SpeechRecognizedEventArgs);
begin
  if (e.Result.Text = 'вперед') then
  begin
    robot.MoveForward();
    Console.WriteLine('вперед!');
  end;
  if (e.Result.Text = 'назад') then
  begin
    robot.MoveBack();
    Console.WriteLine('назад!');
  end;
  if (e.Result.Text = 'влево') then
  begin
    robot.TurnLeft();
    Console.WriteLine('влево!');
  end;
  if (e.Result.Text = 'вправо') then
  begin
    robot.TurnRight();
    Console.WriteLine('вправо!');
  end;
  if (e.Result.Text = 'конец') then
  begin
    Console.WriteLine('конец!');
    completed.Set();
  end;
end;

begin
  completed := new ManualResetEvent(false);
  
  var culture := new CultureInfo('ru-ru');
  var speechEngine := new SpeechRecognitionEngine(culture);
  
  var choices := new Choices();
  choices.Add('вперед');
  choices.Add('назад');
  choices.Add('влево');
  choices.Add('вправо');
  choices.Add('конец');
  
  var grammarBuilder := new GrammarBuilder();
  grammarBuilder.Append(choices);
  var grammar := new Grammar(grammarBuilder);
  speechEngine.LoadGrammar(grammar);
  
  speechEngine.SpeechRecognized += speechEngine_SpeechRecognized; 
  
  speechEngine.SetInputToDefaultAudioDevice();
  speechEngine.RecognizeAsync(RecognizeMode.Multiple);
  
  completed.WaitOne();
  speechEngine.Dispose();
end.