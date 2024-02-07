cmake_minimum_required(VERSION 3.8)
project(cpp_multi_agent_system)

if(CMAKE_COMPILER_IS_GNUCXX OR CMAKE_CXX_COMPILER_ID MATCHES "Clang")
  add_compile_options(-Wall -Wextra -Wpedantic)
endif()

find_package(ament_cmake REQUIRED)
find_package(rclcpp REQUIRED)
find_package(std_msgs REQUIRED)

add_executable(tcpConnector src/TcpConnector.cpp)
ament_target_dependencies(tcpConnector rclcpp std_msgs)

add_executable(doOperation src/DoOperation.cpp)
ament_target_dependencies(doOperation rclcpp std_msgs)

install(TARGETS
  tcpConnector
  doOperation
  DESTINATION lib/${PROJECT_NAME})

ament_package()
