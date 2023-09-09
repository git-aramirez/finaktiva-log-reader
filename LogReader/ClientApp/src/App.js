import "bootstrap/dist/css/bootstrap.min.css"
import './styles/style.css';
import Layout from "antd/es/layout/layout";

import {Form, DatePicker, Button, Input, Select} from 'antd';

const { Option } = Select;

const App = () => {

    const layout = {
        labelCol: {
            span: 8,
        },
        wrapperCol: {
            span: 16,
        },
    };

    const validateMessages = {
        required: '${label} is required!',
    };

    const onFinish = (values) => {
        console.log(values);
    };

    const config = {
        rules: [
            {
                type: 'object',
                required: true,
                message: 'Please select time!',
            },
        ],
    };

    return (
        <Layout className="layout">

            <Form  {...layout} name="nest-messages" onFinish={onFinish}
                style={{maxWidth: 600,}} validateMessages={validateMessages}
            >
                <Form.Item name="select" label="Event" hasFeedback
                    rules={[{ required: true, message: 'Please select the event!' }]}
                >
                    <Select placeholder="Please select an event">
                        <Option value="china">Delete</Option>
                        <Option value="china">Create</Option>
                        <Option value="usa">Update</Option>
                    </Select>
                </Form.Item>

                <Form.Item name={['user', 'description']} label="Desciption" rules={[{ required: true, },]}>
                    <Input.TextArea />
                </Form.Item>

                <Form.Item name="date-time-picker" label="Date" {...config} rules={[{ required: true, },]}>
                    <DatePicker showTime format="YYYY-MM-DD HH:mm:ss" />
                </Form.Item>

                <Form.Item wrapperCol={{ ...layout.wrapperCol, offset: 8, }}>
                    <Button type="primary" htmlType="submit">
                        Submit
                    </Button>
                </Form.Item>
            </Form>

        </Layout >
    )
}

export default App;
