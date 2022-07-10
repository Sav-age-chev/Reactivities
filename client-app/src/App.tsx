import React, { useEffect, useState } from "react";
import logo from "./logo.svg";
import "./App.css";
import axios from "axios"; // Promise based HTTP client
import { Header, List } from "semantic-ui-react";

function App() {
  const [activities, setActivities] = useState([]);

  // Fetch the data from the API of the server and set the activities state
  useEffect(() => {
    axios.get("http://localhost:5000/api/activities").then((response) => {
      console.log(response); // <-------- DIAGNOSTIC -----------
      setActivities(response.data);
    });
  }, []);

  return (
    <div>
      <Header as="h2" icon="users" content="Reactivities" />

      <List>
        {activities.map((activity: any) => (
          <List.Item key={activity.id}>{activity.title}</List.Item>
        ))}
      </List>
    </div>
  );
}

export default App;
