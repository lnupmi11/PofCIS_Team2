import React from 'react';
import { render } from 'react-dom';
import { AppContainer } from 'react-hot-loader';
import Root from './views/Root';
import { configureStore, history } from './data/store/configureStore';
import './assets/app.global.css';

const store = configureStore();

render(
	<AppContainer>
		<Root store={store} history={history} />
	</AppContainer>,
	document.getElementById('root')
);

if (module.hot) {
	module.hot.accept('./views/Root', () => {
		const NextRoot = require('./views/Root'); // eslint-disable-line global-require
		render(
			<AppContainer>
				<NextRoot store={store} history={history} />
			</AppContainer>,
			document.getElementById('root')
		);
	});
}
