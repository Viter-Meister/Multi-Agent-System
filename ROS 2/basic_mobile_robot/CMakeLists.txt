cmake_minimum_required(VERSION 3.8)
project(basic_mobile_robot)

if(CMAKE_COMPILER_IS_GNUCXX OR CMAKE_CXX_COMPILER_ID MATCHES "Clang")
  add_compile_options(-Wall -Wextra -Wpedantic)
endif()

find_package(ament_cmake REQUIRED)
find_package(rclcpp REQUIRED)
find_package(std_msgs REQUIRED)
find_package(geometry_msgs REQUIRED)

add_executable(PascalCommandSubscriberNode src/PascalCommandSubscriberNode.cpp)
ament_target_dependencies(PascalCommandSubscriberNode rclcpp std_msgs)

add_executable(RobotControllerNode src/RobotControllerNode.cpp)
ament_target_dependencies(RobotControllerNode rclcpp std_msgs geometry_msgs)

add_executable(PascalFormattingCommandNode src/PascalFormattingCommandNode.cpp)
ament_target_dependencies(PascalFormattingCommandNode rclcpp std_msgs)

install(TARGETS
  PascalCommandSubscriberNode
  RobotControllerNode
  PascalFormattingCommandNode
  DESTINATION lib/${PROJECT_NAME})
  
install(
  DIRECTORY launch config meshes models rviz src
  DESTINATION share/${PROJECT_NAME}
)

ament_package()
