import { combineReducers } from 'redux';
import { connectRouter } from 'connected-react-router';
import canvas from './modules/canvas';

const createRootReducer = (history: {}) => connectRouter(history)(combineReducers({
	canvas
}));

export default createRootReducer;
