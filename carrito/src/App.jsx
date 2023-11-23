import { Route, Routes } from 'react-router-dom'
import Login from './components/Login'
import Product from './components/Product'
import Home from './components/Home'

function App() {
  return (
    <Routes>
      <Route path='/' element={<Home/>}/>
      <Route path='login' element={<Login />}/>
      <Route path='producto' element={<Product/>}/>
    </Routes>
  )
}

export default App
