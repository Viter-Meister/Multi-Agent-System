#include <memory>
#include <vector>
#include "rclcpp/rclcpp.hpp"
#include "std_msgs/msg/string.hpp"

using std::placeholders::_1;

class PascalFormattingCommandNode : public rclcpp::Node
{
	public:
	PascalFormattingCommandNode(): Node("pascal_formatting_command_node")
	{
 		publisher_ = this->create_publisher<std_msgs::msg::String>("pascal_command", 10);
		subscription_ = this->create_subscription<std_msgs::msg::String>(
		"get_command", 10, std::bind(&PascalFormattingCommandNode::topic_callback, this, _1));
	}

	private:
	std::vector<std::string> split(std::string const &input, const char* delim) const
	{
		std::vector<std::string> result;	
		char *token = strtok(const_cast<char*>(input.c_str()), delim);
		
		while (token != nullptr)
		{
			result.push_back(std::string(token));
			token = strtok(nullptr, delim);
		}
		
		return result;
	}
	
	void topic_callback(const std_msgs::msg::String & msg) const
	{
		auto data = msg.data.c_str();		
 
    	std::vector<std::string> commands = split(data, ";");
 
 		auto message = std_msgs::msg::String();
    	for (auto command: commands) 
    	{
        	RCLCPP_INFO(this->get_logger(), "I heard: '%s'\n", command.c_str());
        	
        	auto values = split(command, ",");
        	
        	for (size_t i = 0; i < values.size(); i++)
        	{
        		auto value = split(values[i], ":");
        		
        		if (value[0] == "ROBOT")
        		{
        			continue;
        		}
        		else if (value[0] == "VALUE")
        		{
        			continue;
        		}
        		else if (value[0] == "OPERATION")
        		{
        			message.data = value[1].c_str();
        			continue;
        		}
        	}
        	
        	RCLCPP_INFO(this->get_logger(), "I publish: '%s'\n", message.data.c_str());
        	publisher_->publish(message);
    	}
	}

	rclcpp::Subscription<std_msgs::msg::String>::SharedPtr subscription_;
	rclcpp::Publisher<std_msgs::msg::String>::SharedPtr publisher_;
};

int main(int argc, char * argv[])
{
	rclcpp::init(argc, argv);
	rclcpp::spin(std::make_shared<PascalFormattingCommandNode>());
	rclcpp::shutdown();
	return 0;
}
