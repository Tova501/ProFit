import { Provider } from 'react-redux';
import store from './redux/store';
import Register from './components/authertication/Register';
import Login from './components/authertication/Login';
function App() {
    return (
        <Provider store={store}>
            <Register/>
            <Login />
        </Provider>
    );
}

export default App;
