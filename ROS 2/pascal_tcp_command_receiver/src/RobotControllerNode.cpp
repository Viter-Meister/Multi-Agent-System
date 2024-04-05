#include "rclcpp/rclcpp.hpp"
#include "std_msgs/msg/string.hpp"
#include "geometry_msgs/msg/twist.hpp"
#include <chrono>

class RobotControllerNode : public rclcpp::Node
{
public:
    RobotControllerNode() : Node("robot_controller_node")
    {
        publisher_ = this->create_publisher<geometry_msgs::msg::Twist>("demo/cmd_vel", 10);
        subscription_ = this->create_subscription<std_msgs::msg::String>("pascal_command", 10, std::bind(&RobotControllerNode::command_callback, this, std::placeholders::_1));
    }

private:
    void command_callback(const std_msgs::msg::String::SharedPtr msg)
    {
        std::string command = msg->data;

        if (command == "MOVE_FORWARD")
            move_forward();
        else if (command == "MOVE_BACK")
            move_backward();
        else if (command == "TURN_LEFT")
            turn_left();
        else if (command == "TURN_RIGHT")
            turn_right();
        else
        	RCLCPP_INFO(this->get_logger(), "Unknown command: %s", command.c_str());
    }

    void move_forward()
    {
    	RCLCPP_INFO(this->get_logger(), "I heard: MOVE_FORWARD");
    	
        auto twist = geometry_msgs::msg::Twist();
        twist.linear.x = 0.15;
        twist.angular.z = 0.0;
        publisher_->publish(twist);
        
        double distance_traveled = 0;
        auto start_time_ = std::chrono::high_resolution_clock::now();
        while (distance_traveled < 2)
        {
        	auto end_time = std::chrono::high_resolution_clock::now();
        	std::chrono::duration<double> elapsed_time = end_time - start_time_;
        	distance_traveled = 0.5 * elapsed_time.count();
        	RCLCPP_INFO(this->get_logger(), "distance_traveled %f", distance_traveled);
        }
        stopMoving();
    }

    void move_backward()
    {
    	RCLCPP_INFO(this->get_logger(), "I heard: MOVE_BACK");
        
        auto twist = geometry_msgs::msg::Twist();
        twist.linear.x = -0.15;
        twist.angular.z = 0.0;
        publisher_->publish(twist);
        
        double distance_traveled = 0;
        auto start_time_ = std::chrono::high_resolution_clock::now();
        while (distance_traveled < 1)
        {
        	auto end_time = std::chrono::high_resolution_clock::now();
        	std::chrono::duration<double> elapsed_time = end_time - start_time_;
        	distance_traveled = 0.5 * elapsed_time.count();
        	RCLCPP_INFO(this->get_logger(), "distance_traveled %f", distance_traveled);
        }
        stopMoving();
    }

    void turn_left()
    {
    	RCLCPP_INFO(this->get_logger(), "I heard: TURN_LEFT");
        
        auto twist = geometry_msgs::msg::Twist();
        twist.linear.x = 0.0;
        twist.angular.z = -0.5;
        publisher_->publish(twist);
        
        double distance_traveled = 0;
        auto start_time_ = std::chrono::high_resolution_clock::now();
        while (distance_traveled < 0.2)
        {
        	auto end_time = std::chrono::high_resolution_clock::now();
        	std::chrono::duration<double> elapsed_time = end_time - start_time_;
        	distance_traveled = 0.5 * elapsed_time.count();
        	RCLCPP_INFO(this->get_logger(), "distance_traveled %f", distance_traveled);
        }
        stopMoving();
    }

    void turn_right()
    {
    	RCLCPP_INFO(this->get_logger(), "I heard: TURN_RIGHT");
        
        auto twist = geometry_msgs::msg::Twist();
        twist.linear.x = 0.0;
        twist.angular.z = 0.5;
        publisher_->publish(twist);
        
        double distance_traveled = 0;
        auto start_time_ = std::chrono::high_resolution_clock::now();
        while (distance_traveled < 0.2)
        {
        	auto end_time = std::chrono::high_resolution_clock::now();
        	std::chrono::duration<double> elapsed_time = end_time - start_time_;
        	distance_traveled = 0.5 * elapsed_time.count();
        	RCLCPP_INFO(this->get_logger(), "distance_traveled %f", distance_traveled);
        }
        stopMoving();
    }
    
     void stopMoving()
    {
        auto twist = geometry_msgs::msg::Twist();
        twist.linear.x = 0.0;
        twist.angular.z = 0.0;
        publisher_->publish(twist);
        
        RCLCPP_INFO(this->get_logger(), "Stopped moving.");
    }

    rclcpp::Publisher<geometry_msgs::msg::Twist>::SharedPtr publisher_;
    rclcpp::Subscription<std_msgs::msg::String>::SharedPtr subscription_;
};

int main(int argc, char *argv[])
{
    rclcpp::init(argc, argv);
    rclcpp::spin(std::make_shared<RobotControllerNode>());
    rclcpp::shutdown();
    return 0;
}
