import React from 'react';
import PropTypes from 'prop-types';
import { Provider } from 'react-redux';
import { createMuiTheme } from '@material-ui/core/styles';
import deepPurple from '@material-ui/core/colors/deepPurple';
import pink from '@material-ui/core/colors/pink';
import MuiThemeProvider from '@material-ui/core/styles/MuiThemeProvider';
import App from './App';

const theme = createMuiTheme({
	palette: {
		primary: deepPurple,
		secondary: pink
	},
	typography: {
		useNextVariants: true
	}
});

const Root = ({ store }) => (
	<Provider store={store}>
		<MuiThemeProvider theme={theme}>
			<App />
		</MuiThemeProvider>
	</Provider>
);

Root.propTypes = {
	/* eslint-disable react/forbid-prop-types */
	store: PropTypes.object.isRequired
};

export default Root;
