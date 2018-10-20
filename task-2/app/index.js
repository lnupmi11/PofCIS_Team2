import React from 'react';
import { render } from 'react-dom';
import { AppContainer } from 'react-hot-loader';
import { ipcRenderer } from 'electron';
import Root from './views/Root';
import store from './data/store';
import './assets/app.global.css';
import { loadFigures, saveFigures } from './data/modules/canvas';

render(
	<AppContainer>
		<Root store={store} />
	</AppContainer>,
	document.getElementById('root')
);

if (module.hot) {
	module.hot.accept('./views/Root', () => {
		const NextRoot = require('./views/Root'); // eslint-disable-line global-require
		render(
			<AppContainer>
				<NextRoot store={store} />
			</AppContainer>,
			document.getElementById('root')
		);
	});
}

ipcRenderer
	.on('save', () => {
		const { filename, figures } = store.getState().canvas;
		if (filename) saveFigures(store.dispatch)(filename, figures);
	})
	.on('open', (e, filename) => {
		if (filename) loadFigures(store.dispatch)(filename);
	})
	.on('new', (e, filename) => {
		if (filename) saveFigures(store.dispatch)(filename, []);
	});
