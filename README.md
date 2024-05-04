<a name="readme-top"></a>



[![Contributors][contributors-shield]][contributors-url]
[![Forks][forks-shield]][forks-url]
[![Stargazers][stars-shield]][stars-url]
[![Issues][issues-shield]][issues-url]
[![MIT License][license-shield]][license-url]



<!-- PROJECT LOGO -->
<br />
<div align="center">
  <a href="https://github.com/Spoky-Loki/Multi-Agent-System">
    <img src="https://github.com/Spoky-Loki/Multi-Agent-System/blob/main/Images/logo.png" alt="Logo" width="100" height="100">
  </a>

  <h3 align="center">Multi-Agent-System</h3>

  <p align="center">
    Репозиторий для дипломного проекта. 
    <br />
    Тема: "Многоагентная система PascalABC-ROS2-Unity"
    <br />
    <a href="https://github.com/Spoky-Loki/Multi-Agent-System/issues/new?labels=bug&template=bug-report---.md">Сообщить об ошибке</a>
    ·
    <a href="https://github.com/Spoky-Loki/Multi-Agent-System/issues/new?labels=enhancement&template=feature-request---.md">Предложить фичу</a>
  </p>
</div>



<!-- TABLE OF CONTENTS -->
<details>
  <summary>Cодержание</summary>
  <ol>
    <li>
      <a href="#о-проекте">О Проекте</a>
      <ul>
        <li><a href="#разработан-с-использованием">Разработан с использованием</a></li>
      </ul>
    </li>
    <li>
      <a href="#подготовка-к-работе">Подготовка к работе</a>
      <ul>
        <li><a href="#необходимые-компоненты">Необходимые компоненты</a></li>
        <li><a href="#установка">Установка</a></li>
      </ul>
    </li>
    <li><a href="#использование">Использование</a></li>
    <li><a href="#участвовать-в-разработке-проекта">Участвовать в разработке проекта</a></li>
    <li><a href="#лицензия">Лицензия</a></li>
    <li><a href="#контакты">Контакты</a></li>
    <li><a href="#благодарности">Благодарности</a></li>
  </ol>
</details>



<!-- ABOUT THE PROJECT -->
# О Проекте

[![Product Name Screen Shot][product-screenshot]](https://github.com/Spoky-Loki/Multi-Agent-System)

Проект "Многоагентная система PascalABC, ROS2, Unity" представляет собой интеграцию трёх технологий для создания интеллектуальных агентских систем.

* `PascalABC` - это язык программирования, который используется в данном проекте для отправки команд роботу.
* `ROS2` - это система для создания роботов, в данном проекте она позволяет роботу получать и выполнять команды от PascalABC.
* `Unity` - это движок для создания видеоигр, в данном проекте используется как средство визуализации робота и его окружения.

В рамках проекта разработаны следующие модули:
* `PascalABC-Robot-Command` - модуль, который позволяет создавать программы для управления роботом.
* `PascalABC-Robot-Speech-Command` - модуль, который позволяет управлять роботом с помощью голосовых команд.
* `PascalABC-ROS2-Bridge` - модуль, который обеспечивает связь между PascalABC и ROS2.
* `ROS2-Simple-Mobile-Robot` - модуль, который содержит описание робота.
* `Unity-Robotics-Scene` - модуль, который содержит визуальную модель робота и его окружения.

Для связи между ROS2 и Unity используется решение предоставляемое Unity Technologies модуль `Unity-Robotics-Hub`, который включает в себя:
* `ROS TCP Endpoint` - Узел ROS для отправки/получения сообщений от Unity.
* `ROS TCP Connector` - Пакет Unity для отправки, получения и визуализации сообщений от ROS.
* `URDF Importer` - Пакет Unity для загрузки URDF-файлов.

Проект предоставляет возможность создавать интеллектуальные агентские системы, которые могут быть использованы в различных областях, таких как наука, техника, искусство и развлечения.

<p align="right">(<a href="#readme-top">вернуться к началу</a>)</p>



### Разработан с использованием

* [![Ros][Ros.js]][Ros-url]
* [![Unity][Unity.js]][Unity-url]
* [![Pascal][Pascal.js]][Pascal-url]

<p align="right">(<a href="#readme-top">вернуться к началу</a>)</p>



<!-- GETTING STARTED -->
# Подготовка к работе

Для того чтобы запустить локальную копию проекта "Многоагентная система PascalABC, ROS2, Unity 3D" необходимо выполнить следующие простые действия.

## Необходимые компоненты

Для работы системы необходимо установить и настроить следующие компоненты:
* PascalABC.NET
  ```
  Скачать и установить последнюю версию системы программирования PascalABC.NET

  Ссылки для скачивания: https://pascalabc.net/ssyilki-dlya-skachivaniya
  ```
* ROS2
  ```
  Скачать и установить ROS2 Humble (рекомендация устанавливать версию для Ubuntu)

  Ссылки на инструкцию по скачиванию и установки: https://docs.ros.org/en/humble/Installation.html
  ```
* Oracle VM VirtualBox (опционально)
  ```
  Если решили устанавливать ROS2 на Ubuntu, а данная ОС у вас не установленна, то можно воспользоваться виртуальной машиной.

  Скачать и установить последнюю версию Oracle VM VirtualBox
  Ссылки для скачивания: https://www.virtualbox.org/wiki/Downloads

  Ссылка по настройке Ubuntu под Oracle VM VirtualBox: https://ubuntu.com/tutorials/how-to-run-ubuntu-desktop-on-a-virtual-machine-using-virtualbox#1-overview
  ```
* Unity (опционально)
  ```
  Если собираетесь модифицировать тестовую сцену и модель робота, то необходимо установить игровой движок Unity.
  Ссылка для скачивания: https://unity.com/ru/download
  ```
## Установка

Порядок установки и настройки системы:

1. Клонировать репозиторий
   ```sh
   git clone https://github.com/Spoky-Loki/Multi-Agent-System.git
   ```
2. Перенесите модули из папки `ROS 2` копии этого репозитория в свою рабочую директорию `ROS2`.
    <br/>
  Выполните сборку командой:
    ```sh
    colcon build
    ```
    Настроить среду командой:
      ```sh
      . install/setup.bash
      ```
3. Запустите `ROS-TCP-Endpoint` для этого выполните команду:
    ```sh
    . install/setup.bash
    ros2 run ros_tcp_endpoint default_server_endpoint --ros-args -p ROS_IP:=<your IP>
    ```
    Следует указывать IP адрес вашей системы Ubuntu, его можно узнать следующей командой:
    ```sh
    hostname -I
    ```
    Если вы используете виртуальную машину, то, для того чтобы иметь возможность обмениваться данными между основной ОС и виртуальной, необходимо подключить виртуальную машину к локальной сети. 
    <br/>
    Для этого лучше всего настроить сеть виртуальной машины на использования сетевого моста.
4. В новом окне терминала запустите `PascalABC-ROS2-Bridge` для этого выполните команду:
    ```sh
    . install/setup.bash
    ros2 launch pascal_tcp_command_receiver pascal_tcp_command_receiver.launch.py ip:=<your IP>
    ```
    Следует указывать IP адрес вашей основной ОС, его можно узнать следующей командой:
    ```sh
    ipconfig
    ```
    Строка содержащая IPv4-адрес.
5. В новом окне терминала запустите  `RVIZ` с моделью робота (опционально)
    ```sh
    ros2 launch basic_mobile_robot basic_mobile_bot.launch.py
    ```
6. Скачать и запустить сборку проекта Unity.
    <br/>
    В настройках укажите IP адрес, который использовался для запуска `ROS-TCP-Endpoint`.
    <br/>
    Начните симуляцию.
7. Использование `PascalABC`
    <br/>
    Если вы хотите управлять роботом с помощью голосовых команд, то откройте и запустите программу `Speech.pas` из директории `PascalABC`.
    <br/>
    Если вы собираетесь создавать программы для управления роботом, то откройте файл `Main.pas` и после комментария пишите свой код, после чего запустите программу.
<p align="right">(<a href="#readme-top">вернуться к началу</a>)</p>



<!-- USAGE EXAMPLES -->
# Использование

### Пример из проекта

Пример робота из этого проекта может распознавать 4 команды: `Вперед`, `Назад`, `Влево`, `Вправо`.
<br/>
Для голосового управления можно использовать команды: `Вперед`, `Назад`, `Влево`, `Вправо`, `Конец`.
<br/>
При создании программ можно использовать команды: `robot.MoveForward()`, `robot.MoveBack()`, `robot.TurnLeft()`, `robot.TurnRigth()`.
<br/>
<br/>
В демонстрационной сцене роботу нужно проехать по заданному маршруту и собрать все монетки по пути.

## Модифицировать сцену и робота в Unity

Открыть проект Unity из копии этого репозитория в редакторе Unity.
<br/>
<br/>
Для изменения окружения используйте стандартные средства Unity.
<br/>
<br/>
Для изменения модели робота необходимо создать его описание в формате URDF и поместить его в папку `Assets/URDF`, также добавьте URDF файл в модуль `basic_mobile_robot` расположенный в вашей рабочей директории ROS2 в директорию `models`.
<br/>
Меши и Материалы для робота поместить соответственно в папки `Assets/URDF/meshes` и `Assets/URDF/Materials`, тажке добавьте меши в модуль `basic_mobile_robot` расположенный в вашей рабочей директории ROS2 в директорию `meshes`.
<br/>
Далее импортировать модель в сцену можно следующим образом:
1. Щелкните правой кнопкой мыши на файле URDF и выберите команду `Import Robot from Selected URDF file`
2. Появится окно с настройками импорта для робота.
3. Нажмите `Import URDF`

## Модифицировать или добавить команды

### Модификация команд в PascalABC

Для добавления или изменения команд откройте файл `Robotics.pas` из директории `PascalABC`.

Для изменения команд модифицируйте функции соответствующие команде, например для команды `вперед`:
```Pascal
function MoveForward(): string;
  begin
    Result := $'ROBOT:{fName},OPERATION:MOVE_FORWARD;';
  end;
```

Для добавления команд используйте следующий пример:
```Pascal
function Command(): string;
  begin
    Result := $'ROBOT:{fName},OPERATION:COMMAND;';
  end;
```

### Модификация голосовых команд PascalABC

Для добавления или изменения голосовых команд откройте файл `Speech.pas` из директории `PascalABC`.

Изменить команды можно следующим образом:

1. Найти строку `var choices := new Choices();`.
2. Изменить команды в строках ниже `choices.Add('команда');`.
3. Изменить соответствующие команды в функции `speechEngine_SpeechRecognized`.

Для добавления команд:

1. Найти строку `var choices := new Choices();`
2. Добавить команду после всех существующих с помощью `choices.Add('команда');`.
3. Также добавить команды в функцию `speechEngine_SpeechRecognized` по примеру:
    ```Pascal
    if (e.Result.Text = 'команда') then
    begin
      server.Send(robot.Command());
      server.Start();
    end;
    ```
(Не забудьте добавить команды в `Robotics.pas`)

### Модификация команд в ROS2

1. Перейдите в модуль `pascal_tcp_command_receiver` расположенный в вашей рабочей директории ROS2.
2. Перейдите в директорию `src`.
3. Откройте файл `RobotControllerNode.cpp`.
4. Добавьте или измените команду в функции `command_callback`.
5. Добавьте или измените функцию обработки команды по следующему примеру:
    ```CPP
    void Command()
    {
      RCLCPP_INFO(this->get_logger(), "I heard: COMMAND");

      // Обработка команды

      stopMoving();
    }
    ```
6. Сделайте сборку и запустить модули.

<p align="right">(<a href="#readme-top">вернуться к началу</a>)</p>



<!-- CONTRIBUTING -->
# Участвовать в разработке проекта

Если у вас есть предложения, которые могли бы улучшить проект, пожалуйста сделайте Форк репозитория и создайте Pull Request. Вы также можете просто открыть Issues с тегом "enhancement".
Не забудьте отметить проект звездочкой! Еще раз спасибо!

1. Сделайте Форк проекта
2. Создайте ветку со своей Фичей (`git checkout -b feature/AmazingFeature`)
3. Зафиксируйте свои изменения (`git commit -m 'Add some AmazingFeature'`)
4. Залейте изменения на ветку (`git push origin feature/AmazingFeature`)
5. Откройте Pull Request

<p align="right">(<a href="#readme-top">вернуться к началу</a>)</p>



<!-- LICENSE -->
# Лицензия

Распространяется по лицензии MIT. Дополнительную информацию смотрите в `LICENSE.md`.

<p align="right">(<a href="#readme-top">вернуться к началу</a>)</p>



<!-- CONTACT -->
# Контакты

Витер Виктор - [@Spoky_Loki](https://t.me/Spoky_Loki) - viter02@inbox.ru

Ссылка на проект: [https://github.com/Spoky-Loki/Multi-Agent-System.git](https://github.com/Spoky-Loki/Multi-Agent-System)

<p align="right">(<a href="#readme-top">вернуться к началу</a>)</p>



<!-- ACKNOWLEDGMENTS -->
# Благодарности

* [Unity Robotics Hub](https://github.com/Unity-Technologies/Unity-Robotics-Hub)
* [The Ultimate Guide to the ROS 2 Navigation Stack](https://automaticaddison.com/the-ultimate-guide-to-the-ros-2-navigation-stack/)
* [ROS 2 Documentation](https://docs.ros.org/en/humble/index.html)

<p align="right">(<a href="#readme-top">вернуться к началу</a>)</p>



<!-- MARKDOWN LINKS & IMAGES -->
<!-- https://www.markdownguide.org/basic-syntax/#reference-style-links -->
[contributors-shield]: https://img.shields.io/github/contributors/Spoky-Loki/Multi-Agent-System.svg?style=for-the-badge
[contributors-url]: https://github.com/Spoky-Loki/Multi-Agent-System/graphs/contributors
[forks-shield]: https://img.shields.io/github/forks/Spoky-Loki/Multi-Agent-System.svg?style=for-the-badge
[forks-url]: https://github.com/Spoky-Loki/Multi-Agent-System/network/members
[stars-shield]: https://img.shields.io/github/stars/Spoky-Loki/Multi-Agent-System.svg?style=for-the-badge
[stars-url]: https://github.com/Spoky-Loki/Multi-Agent-System/stargazers
[issues-shield]: https://img.shields.io/github/issues/Spoky-Loki/Multi-Agent-System.svg?style=for-the-badge
[issues-url]: https://github.com/Spoky-Loki/Multi-Agent-System/issues
[license-shield]: https://img.shields.io/github/license/Spoky-Loki/Multi-Agent-System.svg?style=for-the-badge
[license-url]: https://github.com/Spoky-Loki/Multi-Agent-System/blob/master/LICENSE.md
[product-screenshot]: https://github.com/Spoky-Loki/Multi-Agent-System/blob/main/Images/collages.png
[Unity.js]: https://img.shields.io/badge/unity-3d?style=for-the-badge&logo=Unity&logoColor=white&color=black
[Unity-url]: https://unity.com/
[Pascal.js]: https://img.shields.io/badge/PascalABC.NET-BLUE?style=for-the-badge&logo=PascalABC.NET&logoColor=blue&labelColor=green&color=green
[Pascal-url]: https://pascalabc.net/
[Ros.js]: https://img.shields.io/badge/ROS-2?style=for-the-badge&logo=ROS&logoColor=white&color=blue
[Ros-url]: https://www.ros.org/
