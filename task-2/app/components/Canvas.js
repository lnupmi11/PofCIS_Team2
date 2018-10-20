/* eslint-disable react/prop-types,jsx-a11y/click-events-have-key-events,jsx-a11y/no-static-element-interactions */
import React from 'react';
import PropTypes from 'prop-types';
import withStyles from '@material-ui/core/styles/withStyles';

const styles = () => ({
	root: {
		backgroundColor: 'white',
		color: 'black',
		flexGrow: 1
	},
	svg: {
		height: '100%',
		width: '100%'
	}
});

const Ellipse = ({ cx, cy, rx, ry, fill }) => (
	<ellipse
		cx={cx}
		cy={cy}
		rx={rx}
		ry={ry}
		fill={fill}
		strokeWidth={1}
		stroke="black"
	/>
);

const Figure = ({ type, ...props }) => {
	let result;
	switch (type) {
		case 'ellipse':
			result = <Ellipse {...props} />;
			break;
		default:
			result = '';
	}
	return result;
};

class Canvas extends React.Component {
	static propTypes = {
		// eslint-disable-next-line react/forbid-prop-types
		figures: PropTypes.array,
		// eslint-disable-next-line react/forbid-prop-types
		classes: PropTypes.object.isRequired,
		drawEllipse: PropTypes.func.isRequired
	};

	static defaultProps = {
		figures: []
	};

	constructor(props) {
		super(props);
		this.root = React.createRef();
		this.state = {
			points: []
		};
	}

	handleClick = event => {
		const { points } = this.state;
		const { drawEllipse } = this.props;
		const pos = {
			x: event.pageX - this.root.current.offsetLeft,
			y: event.pageY - this.root.current.offsetTop
		};
		const newPoints = [...points, pos];
		if (newPoints.length < 2) this.setState(() => ({ points: newPoints }));
		else {
			drawEllipse(newPoints);
			this.setState(() => ({ points: [] }));
		}
	};

	render() {
		const { figures, classes } = this.props;
		const { points } = this.state;
		return (
			<div className={classes.root} ref={this.root}>
				<svg className={classes.svg} onClick={this.handleClick}>
					{figures &&
						figures.map(figure => (
							<Figure {...figure} key={JSON.stringify(figure)} />
						))}
					{points &&
						points.map(point => (
							<circle
								cx={point.x}
								cy={point.y}
								r="3"
								key={JSON.stringify(point)}
								stroke="black"
								strokeWidth="3"
							/>
						))}
				</svg>
			</div>
		);
	}
}

export default withStyles(styles)(Canvas);
export { Canvas };
