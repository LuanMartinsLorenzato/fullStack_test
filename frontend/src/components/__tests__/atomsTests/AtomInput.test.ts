import { mount } from '@vue/test-utils'
import AtomInput from '../../atoms/AtomInput.vue'
import { describe, expect, test } from 'vitest'

describe(AtomInput, () => {
  test('Emits keyup event correct', async () => {
    const wrapper = mount(AtomInput)

    await wrapper.trigger('keyup')
    expect(wrapper.emitted('keyup')).toBeTruthy()
  })
  
})
