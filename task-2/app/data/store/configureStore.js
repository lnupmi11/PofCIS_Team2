module.exports =
	process.env.NODE_ENV === 'production'
		? require('./configureStore.prod') // eslint-disable-line global-require
		: require('./configureStore.dev'); // eslint-disable-line global-require
