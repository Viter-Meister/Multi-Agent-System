unit Robotics;

type
  Robot = class
  private
    fName: string;
  public
    constructor Create(Name: string);
    begin
      fName := Name;
    end;
    
    property Name: string read fName;
    
    function MoveForward: string;
    begin
      Result := $'Robot: {fName}; Operation: move forward';
    end;
    
    function MoveBack: string;
    begin
      Result := $'Robot: {fName}; Operation: move back';
    end;
    
    function MoveRight: string;
    begin
      Result := $'Robot: {fName}; Operation: move right';
    end;
    
    function MoveLeft: string;
    begin
      Result := $'Robot: {fName}; Operation: move left';
    end;
  end;
  
end.