import { applyMiddleware, compose, createStore } from 'redux';
import { createHashHistory } from 'history';
import { createLogger } from 'redux-logger';
import createRootReducer from '../reducer';
import { addEllipse } from '../modules/canvas';

const history = createHashHistory();

const rootReducer = createRootReducer(history);

const configureStore = initialState => {
	// Redux Configuration
	const middleware = [];
	const enhancers = [];

	const logger = createLogger({
		level: 'info',
		collapsed: true
	});

	if (process.env.NODE_ENV !== 'test') {
		middleware.push(logger);
	}

	// Redux DevTools Configuration
	const actionCreators = {
		addEllipse
	};
	// If Redux DevTools Extension is installed use it, otherwise use Redux compose
	/* eslint-disable no-underscore-dangle */
	const composeEnhancers = window.__REDUX_DEVTOOLS_EXTENSION_COMPOSE__
		? window.__REDUX_DEVTOOLS_EXTENSION_COMPOSE__({
				// Options: http://extension.remotedev.io/docs/API/Arguments.html
				actionCreators
		  })
		: compose;
	/* eslint-enable no-underscore-dangle */

	// Apply Middleware & Compose Enhancers
	enhancers.push(applyMiddleware(...middleware));
	const enhancer = composeEnhancers(...enhancers);

	const store = createStore(rootReducer, initialState, enhancer);

	if (module.hot) {
		module.hot.accept(
			'../reducer',
			() => store.replaceReducer(require('../reducer')) // eslint-disable-line global-require
		);
	}

	return store;
};

export default { configureStore, history };
