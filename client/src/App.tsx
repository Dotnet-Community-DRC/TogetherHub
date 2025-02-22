import { useEffect, useState } from "react"

function App() {
  const [activities, setActivities] = useState<Activity[]>([])

  useEffect(() => {
    fetch("https://localhost:5001/api/activities")
      .then((res) => res.json())
      .then(data =>setActivities(data))
  }, [])
  return (
      <div>
        <h3>TogetherHub</h3>
        <ul>
          {activities.map((activity) => (
            <li key={activity.id}>{activity.title}</li>
          ))}
        </ul>
      </div>
  )
}

export default App
