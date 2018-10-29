import React from 'react';
import { CirclePicker } from 'react-color';

class CustomColorPicker extends React.Component {
	constructor(props) {
		super(props);
		this.state = {};
	}

	render() {
		return (
			<div className='color_picker'>
				<CirclePicker style={this.props.inputStyles}
											color={ this.props.background }
											onChangeComplete={ this.props.handleChangeComplete }/>
			</div>
		);
	}
}


export default CustomColorPicker;
